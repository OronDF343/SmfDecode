namespace SmfDecode.Events.Meta
{
    public class ChannelPrefix : MetaEvent
    {
        public ChannelPrefix(byte channel)
        {
            Channel = channel;
        }

        public override byte Type => 0x20;
        public override int Length => 0x01;
        public byte Channel { get; } // 0-15
    }
}