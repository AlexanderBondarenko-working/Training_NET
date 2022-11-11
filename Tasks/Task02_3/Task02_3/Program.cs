using System;
using System.Collections.Generic;
using CustomLogger;

namespace Task02_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new LoggerConfigurations();
            config.ListenerConfigurations = new List<ListenerConfiguration>() { 
                new ListenerConfiguration("TextListener", "TextListenerLog"), 
                new ListenerConfiguration("WordListener", "WordListenerLog"), 
                new ListenerConfiguration("EventLogListener", "EventLogListenerLog") };
            var logger = new Logger(config);

            logger.Debug("test debug");
            logger.Info("test info");
            logger.Warning("test warning");
            logger.Error("test error");
        }
    }
}
