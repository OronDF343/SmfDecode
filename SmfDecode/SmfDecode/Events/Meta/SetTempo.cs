namespace SmfDecode.Events.Meta
{
    public class SetTempo : MetaEvent
    {
        public SetTempo(int microsecondsPerQuarter)
        {
            MicrosecondsPerQuarter = microsecondsPerQuarter;
        }

        public override byte Type => 0x51;
        public override int Length => 0x03;
        public int MicrosecondsPerQuarter { get; } // 24-bit value!
    }
}