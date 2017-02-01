namespace SmfDecode.Events.Meta
{
    public class EndOfTrack : MetaEvent // NOT optional
    {
        public override byte Type => 0x2F;
        public override int Length => 0x00;
    }
}