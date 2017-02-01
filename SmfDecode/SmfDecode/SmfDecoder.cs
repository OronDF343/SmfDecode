using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SmfDecode.Chunks;
using SmfDecode.Events;
using SmfDecode.Events.Meta;

namespace SmfDecode
{
    public class SmfDecoder : IDisposable
    {
        public SmfDecoder(string path, ILogger logger = null, bool useAsync = true, int bufferSize = 4096)
        {
            _source = new BinaryReader(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize,
                                                      (useAsync ? FileOptions.Asynchronous : 0)
                                                      | FileOptions.SequentialScan),
                                       Encoding.ASCII, false);
            _logger = logger;
        }

        public SmfDecoder(Stream file, ILogger logger = null, bool leaveOpen = false)
        {
            _source = new BinaryReader(file, Encoding.ASCII, leaveOpen);
            _logger = logger;
        }

        public SmfDecoder(byte[] data, ILogger logger = null)
            : this(new MemoryStream(data), logger) { }
        
        private readonly BinaryReader _source;
        private byte _lastStatusByte;
        private readonly ILogger _logger;
        private int _ntrks = -1;

        public Chunk ReadChunk()
        {
            var isEof = _source.BaseStream.Position >= _source.BaseStream.Length - 1;
            
            if (_ntrks == 0)
            {
                if (isEof) _logger?.Info(Strings.FinishedAtEnd, _source.BaseStream.Position);
                else _logger?.Warn(Strings.FinishedBeforeEnd, _source.BaseStream.Position);
                return null;
            }
            if (isEof)
            {
                var msg = string.Format(Strings.UnexpectedEofTracks, _ntrks);
                _logger?.Fatal(msg, _source.BaseStream.Position);
                throw new SmfDecoderException(msg, _source.BaseStream.Position);
            }

            // Read the type and length
            var id = Encoding.ASCII.GetString(_source.ReadBytes(4));
            var len = MidiBytesConverter.ReadBigEndianUInt(_source.ReadBytes(4));

            // Begin decoding the data by chunk type
            switch (id)
            {
                case MidiHeader.HeaderIdentifier:
                    if (_ntrks > -1) _logger?.Error(Strings.DuplicateHeader, _source.BaseStream.Position - 8);
                    var next = _source.BaseStream.Position + len;
                    // Read the values
                    var format = MidiBytesConverter.ReadBigEndianUShort(_source.ReadBytes(2));
                    _ntrks = MidiBytesConverter.ReadBigEndianUShort(_source.ReadBytes(2));
                    var div = MidiBytesConverter.ReadBigEndianShort(_source.ReadBytes(2));
                    // Jump to next chunk if case the header is longer than 6 for some reason
                    if (_source.BaseStream.Position < next)
                    {
                        _logger?.Warn(Strings.WrongLength, _source.BaseStream.Position - 10);
                        _source.BaseStream.Position = next;
                    }
                    // Create the header chunk object, taking in to account the time division method used
                    return div < 0 ? new MidiHeader(format, (ushort)_ntrks, (sbyte)(div >> 8), (byte)(div & 0xFF)) : new MidiHeader(format, (ushort)_ntrks, div);
                case MidiTrack.TrackIdentifier:
                    if (_ntrks == -1) _logger?.Warn(Strings.NoHeader, _source.BaseStream.Position - 8);
                    // Read all the events in the track and return the track
                    return new MidiTrack(ReadTrackEvents(len));
                default:
                    _logger?.Error(Strings.UnknownChunk, _source.BaseStream.Position - 8);
                    return new UnknownChunk(id, _source.ReadBytes((int)len));
            }
        }

        private IEnumerable<TrackEvent> ReadTrackEvents(uint len)
        {
            _lastStatusByte = 0;
            var end = _source.BaseStream.Position + len;
            TrackEvent lastEvent = null;
            while (_source.BaseStream.Position < end)
            {
                if (lastEvent?.MidiEvent is EndOfTrack) break; // Notice that this a normal break, not yield!
                lastEvent = ReadTrackEvent();
                yield return lastEvent;
            }
            if (_source.BaseStream.Position < end) _source.BaseStream.Position = end;
        }

        private TrackEvent ReadTrackEvent()
        {
            var deltaTime = ReadVariableLengthEncoding();
            // "Running Status": The last status byte is implied
            var statusByte = _lastStatusByte;
            var firstByte = _source.ReadByte();
            // Check for new status byte
            if ((firstByte & 0x80) == 1)
            {
                statusByte = firstByte;
                firstByte = _source.ReadByte();
            }

            var statusUpper = statusByte >> 4;
            // Save running status
            if (statusUpper > 0x7 && statusUpper < 0xF)
                _lastStatusByte = statusByte;
            // Parse the event
            var statusLower = (byte)(statusByte & 0xF);
            MidiEvent ev = null;
            switch (statusUpper)
            {
                case 0x8:
                    ev = new NoteOff(statusLower, firstByte, _source.ReadByte());
                    break;
                case 0x9:
                    ev = new NoteOn(statusLower, firstByte, _source.ReadByte());
                    break;
                case 0xA:
                    ev = new PolyphonicKeyPressure(statusLower, firstByte, _source.ReadByte());
                    break;
                case 0xB:
                    if (firstByte < 120)
                        ev = new ControlChange(statusLower, firstByte, _source.ReadByte());
                    else
                        ev = new ChannelMode(statusLower, firstByte, _source.ReadByte());
                    break;
                case 0xC:
                    ev = new ProgramChange(statusLower, firstByte);
                    break;
                case 0xD:
                    ev = new ChannelPressure(statusLower, firstByte);
                    break;
                case 0xE:
                    ev = new PitchBend(statusLower, firstByte, _source.ReadByte());
                    break;
                case 0xF:
                    switch (statusLower)
                    {
                        case 0x0:
                        case 0x7:
                            ev = new SysEx(statusLower == 0, _source.ReadBytes(ReadVariableLengthEncoding(firstByte)));
                            break;
                        case 0xF:
                            var len = ReadVariableLengthEncoding();
                            var data = _source.ReadBytes(len);
                            switch (firstByte)
                            {
                                case 0x01:
                                case 0x02:
                                case 0x03:
                                case 0x04:
                                case 0x05:
                                case 0x06:
                                case 0x07:
                                case 0x08:
                                case 0x09:
                                case 0x0A:
                                case 0x0B:
                                case 0x0C:
                                case 0x0D:
                                case 0x0E:
                                case 0x0F:
                                    ev = new TextEvent(Encoding.UTF8.GetString(data)); // TODO: Let user choose encoding
                                    break;
                                case 0x20:
                                    ev = new ChannelPrefix(data[0]);
                                    break;
                                case 0x2F:
                                    ev = new EndOfTrack();
                                    break;
                                case 0x51:
                                    ev = new SetTempo(MidiBytesConverter.ReadBigEndian24bit(data));
                                    break;
                                case 0x54:
                                    ev = new SmpteOffset((byte)((data[0] >> 5) & 0x3), (byte)(data[0] & 0x1F), data[1], data[2], data[3], data[4]);
                                    break;
                                case 0x58:
                                    ev = new TimeSignature(data[0], data[1], data[2], data[3]);
                                    break;
                                case 0x59:
                                    ev = new KeySignature((sbyte)data[0], data[1] == 1);
                                    break;
                                case 0x7F:
                                    ev = new SequencerSpecificMetaEvent(data);
                                    break;
                                default:
                                    // TODO: Unrecognized metadata kind, non-fatal error
                                    break;
                            }
                            break;
                        default:
                            // At this point, if the event was not recognized: FATAL ERROR!
                            throw new NotImplementedException();
                    }
                    break;
                default:
                    // At this point, if the event was not recognized: FATAL ERROR!
                    throw new NotImplementedException();
            }
            
            return new TrackEvent(deltaTime, ev);
        }

        private int ReadVariableLengthEncoding(int initial = 0, int maxBytes = 4)
        {
            var r = initial;
            for (var i = 0; i < maxBytes; ++i)
            {
                var b = _source.ReadByte();
                r = (r << 7) | (b & 0x7F);
                if ((b & 0x80) == 0) break;
            }
            return r;
        }

        public void Dispose()
        {
            _source?.Dispose();
        }
    }

    public class SmfDecoderException : Exception
    {
        public long Position { get; }

        public SmfDecoderException(string msg, long position)
            : base(msg)
        {
            Position = position;
        }
    }
}
