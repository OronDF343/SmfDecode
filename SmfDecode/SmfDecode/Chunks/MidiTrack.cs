using System.Collections.Generic;

namespace SmfDecode.Chunks
{
    public class MidiTrack : Chunk
    {
        public const string TrackIdentifier = "MTrk";

        public MidiTrack()
        {
            Events = new TrackEventCollection();
        }
        public MidiTrack(IEnumerable<TrackEvent> events)
            : this()
        {
            Events.AddRange(events);
        }

        public override string Identifier => TrackIdentifier;
        public override uint Length => Utils.Length(Events);
        public TrackEventCollection Events { get; }
    }
}