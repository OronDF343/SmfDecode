namespace SmfDecode.Events
{
    public class NoteOff : MidiMessage
    {
        public NoteOff(byte channel, byte note, byte velocity)
            : base(channel)
        {
            Note = note;
            Velocity = velocity;
        }

        internal override byte StatusMask => 0x80;
        public byte Note { get; } // 0-127, Middle C = 60
        // NoteOff supports "Release Velocity"
        public byte Velocity { get; } // 0-127, default 64
    }
}