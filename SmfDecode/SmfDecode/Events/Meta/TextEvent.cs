namespace SmfDecode.Events.Meta
{
    public class TextEvent : MetaEvent
    {
        public TextEvent(string text)
        {
            Text = text;
        }

        // Type is 0x01-0x0F
        public override int Length => Text.Length;
        public string Text { get; }
    }
}