// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Logger.cs" author="Thaddeus Thomas">
//
//  Date:       2023-03-28
//  Project:    Logging
//  Solution:   TextToSpeech
// </copyright>
// <summary>
//   The logger.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Logging
{
    using NLog;

    /// <summary>
    ///     The logger.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        ///     The _logger.
        ///     Create an instance of NLog logger
        /// </summary>
        private static readonly ILogger Logged = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     The debug.
        /// </summary>
        /// <param name="message">
        ///     Log a Debug level message
        /// </param>
        public static void Debug(string message)
        {
            Logged.Debug(message);
        }

        /// <summary>
        ///     The error.
        /// </summary>
        /// <param name="message">
        ///     Log an Error level message
        /// </param>
        public static void Error(string message)
        {
            Logged.Error(message: message);
        }

        /// <summary>
        ///     The fatal.
        /// </summary>
        /// <param name="message">
        ///     Log a Fatal level message
        /// </param>
        public static void Fatal(string message)
        {
            Logged.Fatal(message: message);
        }

        /// <summary>
        ///     The info.
        /// </summary>
        /// <param name="message">
        ///     Log an Info level message
        ///     The message.
        /// </param>
        public static void Info(string message)
        {
            Logged.Info(message: message);
        }

        /// <summary>
        ///     The trace.
        /// </summary>
        /// <param name="message">
        ///     Log a Trace level message
        /// </param>
        public static void Trace(string message)
        {
            Logged.Trace(message: message);
        }

        /// <summary>
        ///     The warn.
        /// </summary>
        /// <param name="message">
        ///     Log a Warn level message
        /// </param>
        public static void Warn(string message)
        {
            Logged.Warn(message: message);
        }
    }
}