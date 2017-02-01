namespace SmfDecode.Chunks
{
    public class UnknownChunk : Chunk
    {
        public UnknownChunk(string identifier, byte[] data)
        {
            Identifier = identifier;
            Data = data;
        }

        public override string Identifier { get; }
        public override uint Length => (uint)Data.Length;
        public byte[] Data { get; }
    }
}
