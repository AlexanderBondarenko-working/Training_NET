using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLogger
{
    internal static class LoggerConfigurationsExstentions
    {
        public static bool IsLoggingLevelAllowed(this LoggerConfigurations config, LoggingLevel level)
        {
            return level >= config.MinLoggingLevel;
        }
    }
}
