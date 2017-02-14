namespace SmfDecode
{
    /// <summary>
    /// A wrapper for a logger. Implement this interface using your favorite logging library.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs a message at the Debug level.
        /// </summary>
        /// <param name="msg">The log message.</param>
        /// <param name="position">The position in the file at which the message was reported.</param>
        void Debug(string msg, long position);

        /// <summary>
        /// Logs a message at the Info level.
        /// </summary>
        /// <param name="msg">The log message.</param>
        /// <param name="position">The position in the file at which the message was reported.</param>
        void Info(string msg, long position);

        /// <summary>
        /// Logs a message at the Warn level.
        /// </summary>
        /// <param name="msg">The log message.</param>
        /// <param name="position">The position in the file at which the message was reported.</param>
        void Warn(string msg, long position);

        /// <summary>
        /// Logs a message at the Error level.
        /// </summary>
        /// <param name="msg">The log message.</param>
        /// <param name="position">The position in the file at which the message was reported.</param>
        void Error(string msg, long position);

        /// <summary>
        /// Logs a message at the Fatal level.
        /// </summary>
        /// <param name="msg">The log message.</param>
        /// <param name="position">The position in the file at which the message was reported.</param>
        void Fatal(string msg, long position);
    }
}
