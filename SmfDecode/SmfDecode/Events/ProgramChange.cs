namespace SmfDecode.Events
{
    public class ProgramChange : MidiMessage
    {
        public ProgramChange(byte channel, sbyte patchNumber)
            : base(channel)
        {
            PatchNumber = patchNumber;
        }

        internal override byte StatusMask => 0xC0;
        public sbyte PatchNumber { get; } // 0-127
    }
}