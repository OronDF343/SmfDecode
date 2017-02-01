namespace SmfDecode.Events.Meta
{
    public class SmpteOffset : MetaEvent // In Format 1, must be in Tempo Map (first track)
    {
        public SmpteOffset(byte smpteFps, byte hours, byte minutes, byte seconds, byte frames, byte fractionalFrames)
        {
            SmpteFps = smpteFps;
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            Frames = frames;
            FractionalFrames = fractionalFrames;
        }

        public override sbyte Type => 0x54;
        public override int Length => 0x05;

        public byte SmpteFps { get; } // 0-3, see enum.
        public byte Hours { get; } // 0-23

        public byte Minutes { get; } // 0-59
        public byte Seconds { get; } // 0-59
        public byte Frames { get; } // 0-29
        public byte FractionalFrames { get; } // 0-99, units are 1/100 of a frame ALWAYS
    }
}