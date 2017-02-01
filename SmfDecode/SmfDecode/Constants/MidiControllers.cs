namespace SmfDecode.Constants
{
    // All not listed numbers are undefined except for 0x78-0x7F which are reserved for Channel Mode Messages
    public enum MidiControllers : byte
    {
        // MSB (0x00-0x1F)
        BankSelectMsb = 0x00,
        ModulationMsb = 0x01,
        BreathControllerMsb = 0x02,
        FootControllerMsb = 0x04,
        PortamentoTimeMsb = 0x05,
        DataEntryMsb = 0x06, // *** see spec ***
        ChannelVolumeMsb = 0x07,
        BalanceMsb = 0x08,
        PanMsb = 0x0A,
        ExpressionControllerMsb = 0x0B,
        EffectControl1Msb = 0x0C,
        EffectControl2Msb = 0x0D,
        GeneralPurposeController1Msb = 0x10,
        GeneralPurposeController2Msb = 0x11,
        GeneralPurposeController3Msb = 0x12,
        GeneralPurposeController4Msb = 0x13,
        // LSB (0x20-0x3F)
        BankSelectLsb = 0x20,
        ModulationLsb = 0x21,
        BreathControllerLsb = 0x22,
        FootControllerLsb = 0x24,
        PortamentoTimeLsb = 0x25,
        DataEntryLsb = 0x26, // *** see spec ***
        ChannelVolumeLsb = 0x27,
        BalanceLsb = 0x28,
        PanLsb = 0x2A,
        ExpressionControllerLsb = 0x2B,
        EffectControl1Lsb = 0x2C,
        EffectControl2Lsb = 0x2D,
        GeneralPurposeController1Lsb = 0x30,
        GeneralPurposeController2Lsb = 0x31,
        GeneralPurposeController3Lsb = 0x32,
        GeneralPurposeController4Lsb = 0x33,
        // Single-byte (0x40-0x5F)
        DamperPedal = 0x40, // Sustain
        PortamentoOnOff = 0x41,
        Sostenuto = 0x42,
        SoftPedal = 0x43,
        LegatoFootswitch = 0x44,
        Hold2 = 0x45,
        SoundController1 = 0x46, // default "Sound Variation"
        SoundController2 = 0x47, // default "Timbre/Harmonic Intensity"
        SoundController3 = 0x48, // default "Release Time"
        SoundController4 = 0x49, // default "Attack Time"
        SoundController5 = 0x4A, // default "Brightness"
        SoundController6 = 0x4B,
        SoundController7 = 0x4C,
        SoundController8 = 0x4D,
        SoundController9 = 0x4E,
        SoundController10 = 0x4F,
        GeneralPurposeController5 = 0x50,
        GeneralPurposeController6 = 0x51,
        GeneralPurposeController7 = 0x52,
        GeneralPurposeController8 = 0x53,
        PortamentoControl = 0x54, // *** special behavior! see spec ***
        Effects1Depth = 0x5B, // default "External Effects Depth"
        Effects2Depth = 0x5C, // default "Tremolo Depth"
        Effects3Depth = 0x5D, // default "Chorus Depth"
        Effects4Depth = 0x5E, // default "Celeste (Detune) Depth"
        Effects5Depth = 0x5F, // default "Phaser Depth"
        // Registered parameter control (0x60-0x65) *** special behavior! see spec ***
        DataIncrement = 0x60,
        DataDecrement = 0x61,
        NonRegisteredParameterNumberLsb = 0x62,
        NonRegisteredParameterNumberMsb = 0x63,
        RegisteredParameterNumberLsb = 0x64,
        RegisteredParameterNumberMsb = 0x65,
    }
}