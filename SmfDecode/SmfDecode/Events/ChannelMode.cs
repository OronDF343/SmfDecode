namespace SmfDecode.Events
{
    public class ChannelMode : MidiMessage // Not inheriting from ControlChange due to spec
    {
        public ChannelMode(byte channel, byte modeMessage, byte data)
            : base(channel)
        {
            ModeMessage = modeMessage;
            Data = data;
        }

        internal override byte StatusMask => 0xB0;
        public virtual byte ModeMessage { get; } // 120-127
        public virtual byte Data { get; }
    }
}