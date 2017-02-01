namespace SmfDecode
{
    public interface ILogger
    {
        void Debug(string msg, long position);
        void Info(string msg, long position);
        void Warn(string msg, long position);
        void Error(string msg, long position);
        void Fatal(string msg, long position);
    }
}
