namespace SmfDecode.Events.Meta
{
    public class ChannelPrefix : MetaEvent
    {
        public ChannelPrefix(sbyte channel)
        {
            Channel = channel;
        }

        public override sbyte Type => 0x20;
        public override int Length => 0x01;
        public sbyte Channel { get; } // 0-15
    }
}