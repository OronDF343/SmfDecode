namespace SmfDecode.Chunks
{
    public abstract class Chunk
    {
        public abstract string Identifier { get; } // Length = 4
        public abstract uint Length { get; } // non-inclusive, fixed-length!
    }
}
