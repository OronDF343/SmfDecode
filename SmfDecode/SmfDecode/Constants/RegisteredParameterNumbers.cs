namespace SmfDecode.Constants
{
    // MSB and LSB are sent separately, both 0-127
    public enum RegisteredParameterNumbers : short
    {
        PitchBendSensitivity = 0x0000,
        FineTuning = 0x0001,
        CoarseTuning = 0x0002,
        TuningProgramSelect = 0x0003,
        TuningBankSelect = 0x0004
    }
}