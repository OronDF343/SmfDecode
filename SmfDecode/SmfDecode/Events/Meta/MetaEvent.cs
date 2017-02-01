namespace SmfDecode.Events.Meta
{
    public class MetaEvent : MidiEvent
    {
        public override byte Status => 0xFF;
        public virtual byte Type { get; }
        public virtual int Length { get; } // variable-length encoding!
    }
}