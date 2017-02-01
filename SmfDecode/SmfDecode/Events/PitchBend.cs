namespace SmfDecode.Events
{
    public class PitchBend : MidiMessage
    {
        public PitchBend(byte channel, byte lsb, byte msb)
            : base(channel)
        {
            Lsb = lsb;
            Msb = msb;
        }

        internal override byte StatusMask => 0xE0;
        // 14-bit value (two 7-bit values), the value 0x0040 is the "center" value (It is Little-Endian?!?!?!)
        public byte Lsb { get; } // 0-127, default 0
        public byte Msb { get; } // 0-127, default 64 (0x40)
    }
}