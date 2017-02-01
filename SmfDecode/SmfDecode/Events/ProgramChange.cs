namespace SmfDecode.Events
{
    public class ProgramChange : MidiMessage
    {
        public ProgramChange(byte channel, byte patchNumber)
            : base(channel)
        {
            PatchNumber = patchNumber;
        }

        internal override byte StatusMask => 0xC0;
        public byte PatchNumber { get; } // 0-127
    }
}