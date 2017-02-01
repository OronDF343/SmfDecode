namespace SmfDecode.Events.Meta
{
    public class TimeSignature : MetaEvent
    {
        public TimeSignature(byte numerator, byte denominatorExponent, byte ticksPerMetronomeClick, byte notated32NdsPerQuarter)
        {
            Numerator = numerator;
            DenominatorExponent = denominatorExponent;
            TicksPerMetronomeClick = ticksPerMetronomeClick;
            Notated32ndsPerQuarter = notated32NdsPerQuarter;
        }

        public override sbyte Type => 0x58;
        public override int Length => 0x04;
        public byte Numerator { get; }
        public byte DenominatorExponent { get; }
        public byte Denominator => (byte)(1 << DenominatorExponent);
        public byte TicksPerMetronomeClick { get; }
        public byte Notated32ndsPerQuarter { get; }
    }
}