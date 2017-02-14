namespace SmfDecode.Chunks
{
    /// <summary>
    /// A MIDI chunk.
    /// </summary>
    public abstract class Chunk
    {
        /// <summary>
        /// A 4-character identifier string (in ASCII encoding).
        /// </summary>
        public abstract string Identifier { get; } // Length = 4
        /// <summary>
        /// The length of the chunk (in bytes).
        /// </summary>
        public abstract uint Length { get; } // non-inclusive, fixed-length!
    }
}
