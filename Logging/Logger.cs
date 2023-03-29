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
        // Create an instance of NLog logger
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        // Log a Debug level message
        public static void Debug(string message){
            _logger.Debug(message);
        }

        // Log an Error level message
        public static void Error(string message){
            _logger.Error(message);
        }

        // Log an Error level message with an associated exception
        public static void Error(Exception ex, string message){
            _logger.Error(ex, message);
        }

        // Log a Fatal level message
        public static void Fatal(string message){
            _logger.Fatal(message);
        }

        // Log a Fatal level message with an associated exception
        public static void Fatal(Exception ex, string message){
            _logger.Fatal(ex, message);
        }

        // Log an Info level message
        public static void Info(string message){
            _logger.Info(message);
        }

        // Log a Trace level message
        public static void Trace(string message){
            _logger.Trace(message);
        }

        // Log a Warn level message
        public static void Warn(string message){
            _logger.Warn(message);
        }
    }
}
