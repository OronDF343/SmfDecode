namespace SmfDecode.Events
{
    public class PolyphonicKeyPressure : MidiMessage
    {
        public PolyphonicKeyPressure(byte channel, sbyte note, sbyte value)
            : base(channel)
        {
            Note = note;
            Value = value;
        }

        internal override byte StatusMask => 0xD0;
        public sbyte Note { get; } // 0-127, Middle C = 60
        public sbyte Value { get; } // 0-127
    }
}