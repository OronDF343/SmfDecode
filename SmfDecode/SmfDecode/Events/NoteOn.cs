namespace SmfDecode.Events
{
    public class NoteOn : MidiMessage // Not inheriting from NoteOff to prevent common programmer error
    {
        public NoteOn(byte channel, sbyte note, sbyte velocity)
            : base(channel)
        {
            Note = note;
            Velocity = velocity;
        }

        internal override byte StatusMask => 0x90;
        public sbyte Note { get; } // 0-127, Middle C = 60
        public sbyte Velocity { get; } // 0-127, default 64, 0 is same as NoteOff
    }
}