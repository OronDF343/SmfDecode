namespace SmfDecode.Events
{
    public class ChannelPressure : MidiMessage
    {
        public ChannelPressure(byte channel, sbyte value)
            : base(channel)
        {
            Value = value;
        }

        internal override byte StatusMask => 0xD0;
        public sbyte Value { get; } // 0-127
    }
}