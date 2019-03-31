using MyLoggerApp.LoggersFactory;
using System;
using System.Collections.Generic;

namespace MyLogger
{
    public class LoggerFactoryProvider
    {
        public static List<LoggerFactory> GetAllLoggerFactories()
        {
            return new List<LoggerFactory>() { new TxtLoggerFactory(), new EventLoggerFactory(), new RegistryLoggerFactory() };
        }

        public static LoggerFactory GetLoggerFactory(LoggerTypes loggerType)
        {
            switch (loggerType)
            {
                case LoggerTypes.EventLogger:
                    return new EventLoggerFactory();
                case LoggerTypes.RegistryLogger:
                    return new RegistryLoggerFactory();
                case LoggerTypes.TxtLogger:
                    return new TxtLoggerFactory();
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}