namespace SmfDecode.Events
{
    public class SysEx : MidiEvent
    {
        public SysEx(bool isBegin, byte[] message)
        {
            IsBegin = isBegin;
            Message = message;
        }

        public bool IsBegin { get; }

        public override byte Status => (byte)(IsBegin ? 0xF0 : 0xF7); // TODO: simplify this
        public int Length => Message?.Length ?? 0; // variable-length encoding!
        public byte[] Message { get; }
    }
}