/*
 *  Author:     Thaddeus Thomas
 *  Date:       20230328
 *  Project:    Logging
 *  Solution:   TextToSpeech
 *  
 *  Notes:
 *  
 */

using NLog;
using System;

namespace Logging
{
    public static class Logger
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public static void Debug(string message)
        {
            _logger.Debug(message);
        }

        public static void Error(string message)
        {
            _logger.Error(message);
        }

        public static void Error(Exception ex, string message)
        {
            _logger.Error(ex, message);
        }

        public static void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public static void Fatal(Exception ex, string message)
        {
            _logger.Fatal(ex, message);
        }

        public static void Info(string message)
        {
            _logger.Info(message);
        }

        public static void Trace(string message)
        {
            _logger.Trace(message);
        }
        public static void Warn(string message)
        {
            _logger.Warn(message);
        }
    }
}
