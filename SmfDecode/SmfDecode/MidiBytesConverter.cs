namespace SmfDecode
{
    public static class MidiBytesConverter
    {
        public static uint ReadBigEndianUInt(byte[] buffer, int pos = 0)
        {
            // TODO: verify arguments
            return (uint)((buffer[pos] << 24) | (buffer[pos+1] << 16) | (buffer[pos+2] << 8) | buffer[pos+3]);
        }
        public static int ReadBigEndian24bit(byte[] buffer, int pos = 0)
        {
            // TODO: verify arguments
            return (buffer[pos + 1] << 16) | (buffer[pos + 2] << 8) | buffer[pos + 3];
        }
        public static short ReadBigEndianShort(byte[] buffer, int pos = 0)
        {
            // TODO: verify arguments
            return (short)((buffer[pos + 2] << 8) | buffer[pos + 3]);
        }
        public static ushort ReadBigEndianUShort(byte[] buffer, int pos = 0)
        {
            // TODO: verify arguments
            return (ushort)((buffer[pos + 2] << 8) | buffer[pos + 3]);
        }
    }
}
