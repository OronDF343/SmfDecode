namespace SmfDecode.Events.Meta
{
    public class KeySignature : MetaEvent
    {
        public KeySignature(sbyte signature, bool isMinorKey)
        {
            Signature = signature;
            IsMinorKey = isMinorKey;
        }

        public override byte Type => 0x59;
        public override int Length => 0x02;
        public sbyte Signature { get; } // Positive values are sharps, negative values are flats. -7 to 7.
        public bool IsMinorKey { get; } // true=1, false=0
    }
}