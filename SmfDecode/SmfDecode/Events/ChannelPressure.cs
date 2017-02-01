namespace SmfDecode.Events
{
    public class ChannelPressure : MidiMessage
    {
        public ChannelPressure(byte channel, byte value)
            : base(channel)
        {
            Value = value;
        }

        internal override byte StatusMask => 0xD0;
        public byte Value { get; } // 0-127
    }
}