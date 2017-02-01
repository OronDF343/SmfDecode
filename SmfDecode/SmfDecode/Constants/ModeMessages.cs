namespace SmfDecode.Constants
{
    public enum ModeMessages : byte // *** special behavior for each of these! see spec ***
    {
        AllSoundOff = 120,
        ResetAllControllers = 121,
        LocalControl = 122,
        AllNotesOff = 123, // 124-127 also have this effect
        OmniOff = 124,
        OmniOn = 125,
        MonoOn = 126, // + Poly off
        PolyOn = 127 // + Mono off
    }
}