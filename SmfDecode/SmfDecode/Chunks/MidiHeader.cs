namespace SmfDecode.Chunks
{
    public class MidiHeader : Chunk
    {
        public const string HeaderIdentifier = "MThd";

        private MidiHeader(ushort format, ushort ntrks)
        {
            Format = format;
            Ntrks = ntrks;
        }

        public MidiHeader(ushort format, ushort ntrks, short ticksPerQuarter)
            : this(format, ntrks)
        {
            Division = ticksPerQuarter;
        }

        public MidiHeader(ushort format, ushort ntrks, sbyte fpsNegative, byte ticksPerFrame)
            : this(format, ntrks)
        {
            Division = (short)((fpsNegative << 8) | ticksPerFrame);
        }

        public override string Identifier => HeaderIdentifier;
        public override uint Length => 6;
        public ushort Format { get; }
        public ushort Ntrks { get; }
        public short Division { get; }

        public bool IsFrameDivision => Division >> 15 == 1;
        public ushort TicksPerQuarter => (ushort)(Division & 0x7FFF);
        // This uses negative values only!
        public sbyte FramesPerSecond => (sbyte)(Division >> 8);
        // Utility property for positive values
        public byte PositiveFps => (byte)-FramesPerSecond;
        public byte TicksPerFrame => (byte)(Division & 0xFF);
    }
}