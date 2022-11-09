using System.Diagnostics;

namespace EventLogListener
{
    internal static class LogginLevelExstentions
    {
        public static EventLogEntryType ToEventLogEntryType(this LoggingLevel level)
        {
            switch (level)
            {
                
                case LoggingLevel.Warning:
                    return EventLogEntryType.Warning;
                case LoggingLevel.Error:
                    return EventLogEntryType.Error;
                case LoggingLevel.Debug:
                case LoggingLevel.Info:
                default:
                    return EventLogEntryType.Information;

            }
        }
    }
}
