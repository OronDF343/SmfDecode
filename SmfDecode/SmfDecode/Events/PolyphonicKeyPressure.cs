namespace SmfDecode.Events
{
    public class PolyphonicKeyPressure : MidiMessage
    {
        public PolyphonicKeyPressure(byte channel, byte note, byte value)
            : base(channel)
        {
            Note = note;
            Value = value;
        }

        internal override byte StatusMask => 0xD0;
        public byte Note { get; } // 0-127, Middle C = 60
        public byte Value { get; } // 0-127
    }
}