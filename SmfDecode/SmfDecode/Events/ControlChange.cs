namespace SmfDecode.Events
{
    public class ControlChange : MidiMessage
    {
        public ControlChange(byte channel, byte controller, byte data)
            : base(channel)
        {
            Controller = controller;
            Data = data;
        }

        internal override byte StatusMask => 0xB0;
        // Controllers:
        // 0 through 31 = Set MSB of most continuous Controller Data
        // 32 through 63 = Set LSB for controllers 0 through 31
        // 64 through 95 = Additional single-byte controllers
        // 96 through 101 = Increment/Decrement and Parameter numbers
        // 102 through 119 = Undefined single-byte controllers
        // 120 through 127 = NOT CONTROLLERS. These are used for "Channel Mode" messages.
        // Global controllers can be used on a reciever in Mode 4 (Omni off / Mono) to affect all channels with higher numbers (use 16 for "1 and higher"). Not always supported!
        // Controllers 16-19 (+ the corresponding LSB ones: 48-51) and 80-83 are general-purpose (not assigned to any manufacturer)
        // Controllers 64-69 are switches. OFF = 0-63, ON = 64-127
        public virtual byte Controller { get; } // 0-119
        public virtual byte Data { get; } // 0-127
    }
}