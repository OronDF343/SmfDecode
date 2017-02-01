namespace SmfDecode.Events.Meta
{
    public class SequencerSpecificMetaEvent : MetaEvent
    {
        public SequencerSpecificMetaEvent(byte[] data)
        {
            Data = data;
        }

        public override sbyte Type => 0x7F;
        public override int Length => Data.Length;
        public byte[] Data { get; }
    }
}