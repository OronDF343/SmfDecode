namespace SmfDecode.Events
{
    public abstract class MidiMessage : MidiEvent
    {
        protected MidiMessage(byte channel)
        {
            Channel = channel;
        }

        internal abstract byte StatusMask { get; }
        public override byte Status => (byte)(StatusMask | Channel);
        public byte Channel { get; } // Actually a nibble (4 bits), 0-15
    }
}