namespace SmfDecode
{
    /// <summary>
    /// Utility methods for decoding some binary data in SMF.
    /// </summary>
    public static class MidiBytesConverter
    {
        /// <summary>
        /// Reads a big-endian 32-bit unsigned integer (<see langword="uint"/>).
        /// </summary>
        /// <param name="buffer">The raw bytes.</param>
        /// <param name="pos">The position to begin reading at. Default is 0.</param>
        /// <returns>An unsigned integer.</returns>
        public static uint ReadBigEndianUInt(byte[] buffer, int pos = 0)
        {
            // TODO: verify arguments
            return (uint)((buffer[pos] << 24) | (buffer[pos+1] << 16) | (buffer[pos+2] << 8) | buffer[pos+3]);
        }

        /// <summary>
        /// Reads a big-endian 24-bit unsigned integer.
        /// </summary>
        /// <remarks>Sign-extension is not performed by this method!</remarks>
        /// <param name="buffer">The raw bytes.</param>
        /// <param name="pos">The position to begin reading at. Default is 0.</param>
        /// <returns>An integer.</returns>
        public static int ReadBigEndian24Bit(byte[] buffer, int pos = 0)
        {
            // TODO: verify arguments
            return (buffer[pos + 1] << 16) | (buffer[pos + 2] << 8) | buffer[pos + 3];
        }

        /// <summary>
        /// Reads a big-endian 16-bit signed integer (<see langword="short"/>).
        /// </summary>
        /// <param name="buffer">The raw bytes.</param>
        /// <param name="pos">The position to begin reading at. Default is 0.</param>
        /// <returns>A signed integer.</returns>
        public static short ReadBigEndianShort(byte[] buffer, int pos = 0)
        {
            // TODO: verify arguments
            return (short)((buffer[pos + 2] << 8) | buffer[pos + 3]);
        }

        /// <summary>
        /// Reads a big-endian 16-bit unsigned integer (<see langword="ushort"/>).
        /// </summary>
        /// <param name="buffer">The raw bytes.</param>
        /// <param name="pos">The position to begin reading at. Default is 0.</param>
        /// <returns>An unsigned integer.</returns>
        public static ushort ReadBigEndianUShort(byte[] buffer, int pos = 0)
        {
            // TODO: verify arguments
            return (ushort)((buffer[pos + 2] << 8) | buffer[pos + 3]);
        }
    }
}
