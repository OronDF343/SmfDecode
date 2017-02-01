namespace SmfDecode.Constants
{
    public enum TextEventKinds : byte
    {
        Text = 0x01,
        CopyrightNotice = 0x02,
        TrackName = 0x03,
        InstrumentName = 0x04,
        Lyric = 0x05,
        Marker = 0x06,
        CuePoint = 0x07,
        // The rest (0x08-0x0F) are reserved for undefined kinds of text
    }
}