namespace SmfDecode.Chunks
{
    /// <summary>
    /// A MIDI header chunk
    /// </summary>
    public class MidiHeader : Chunk
    {
        /// <summary>
        /// The identifier for a MIDI header chunk.
        /// </summary>
        public const string HeaderIdentifier = @"MThd";

        private MidiHeader(ushort format, ushort ntrks)
        {
            Format = format;
            Ntrks = ntrks;
        }

        /// <summary>
        /// Creates a new <see cref="MidiHeader"/> with the "ticks per quarter note" time division.
        /// </summary>
        /// <param name="format">The MIDI format of the file.</param>
        /// <param name="ntrks">Number of tracks in the file.</param>
        /// <param name="ticksPerQuarter">Number of MIDI ticks which represent a quarter note. Valid values: 0-127.</param>
        public MidiHeader(ushort format, ushort ntrks, short ticksPerQuarter)
            : this(format, ntrks)
        {
            Division = ticksPerQuarter;
        }

        /// <summary>
        /// Creates a new <see cref="MidiHeader"/> with the "SMPTE frames" time division.
        /// </summary>
        /// <param name="format">The MIDI format of the file.</param>
        /// <param name="ntrks">Number of tracks in the file.</param>
        /// <param name="fpsNegative">Negative value of frames per second. Must be a negative number.</param>
        /// <param name="ticksPerFrame">Number of MIDI ticks which represent a frame.</param>
        public MidiHeader(ushort format, ushort ntrks, sbyte fpsNegative, byte ticksPerFrame)
            : this(format, ntrks)
        {
            Division = (short)((fpsNegative << 8) | ticksPerFrame);
        }

        /// <inheritdoc />
        public override string Identifier => HeaderIdentifier;

        /// <inheritdoc />
        public override uint Length => 6;

        /// <summary>
        /// The MIDI format of the file.
        /// </summary>
        public ushort Format { get; }

        /// <summary>
        /// The number of tracks in the file.
        /// </summary>
        public ushort Ntrks { get; }

        /// <summary>
        /// The encoded time division properties.
        /// </summary>
        public short Division { get; }

        /// <summary>
        /// Indicates whether the "SMPTE frames" time division is used instead of the "ticks per quarter note" time division.
        /// </summary>
        public bool IsFrameDivision => Division >> 15 == 1;

        /// <summary>
        /// Number of MIDI ticks which represent a quarter note.
        /// </summary>
        public ushort TicksPerQuarter => (ushort)(Division & 0x7FFF);

        /// <summary>
        /// Negative value of frames per second.
        /// </summary>
        public sbyte FramesPerSecond => (sbyte)(Division >> 8);

        /// <summary>
        /// Positive value of frames per second.
        /// </summary>
        public byte PositiveFps => (byte)-FramesPerSecond;

        /// <summary>
        /// Number of MIDI ticks which represent a frame.
        /// </summary>
        public byte TicksPerFrame => (byte)(Division & 0xFF);
    }
}