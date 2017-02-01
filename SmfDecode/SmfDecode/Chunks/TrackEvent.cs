using SmfDecode.Events;

namespace SmfDecode.Chunks
{
    public class TrackEvent
    {
        public TrackEvent(int deltaTime, MidiEvent midiEvent)
        {
            DeltaTime = deltaTime;
            MidiEvent = midiEvent;
        }

        public TrackEvent(MidiEvent midiEvent)
            : this(0, midiEvent) { }

        public int DeltaTime { get; } // variable-length encoding!
        public MidiEvent MidiEvent { get; }
    }
}