namespace SmfDecode.Events
{
    public class NoteOff : MidiMessage
    {
        public NoteOff(byte channel, sbyte note, sbyte velocity)
            : base(channel)
        {
            Note = note;
            Velocity = velocity;
        }

        internal override byte StatusMask => 0x80;
        public sbyte Note { get; } // 0-127, Middle C = 60
        // NoteOff supports "Release Velocity"
        public sbyte Velocity { get; } // 0-127, default 64
    }
}