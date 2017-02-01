namespace SmfDecode.Events
{
    public class NoteOn : MidiMessage // Not inheriting from NoteOff to prevent common programmer error
    {
        public NoteOn(byte channel, byte note, byte velocity)
            : base(channel)
        {
            Note = note;
            Velocity = velocity;
        }

        internal override byte StatusMask => 0x90;
        public byte Note { get; } // 0-127, Middle C = 60
        public byte Velocity { get; } // 0-127, default 64, 0 is same as NoteOff
    }
}