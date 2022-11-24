using System;
using System.Diagnostics;

namespace EventLogListener
{
    public class EventLogListener : CustomLogger.IListener
    {
        public string LogName { get; set; } = String.Empty;

        public void Write(object obj)
        {
            throw new NotImplementedException();
        }

        public void Write(string message, LoggingLevel level)
        {
            var processName = Process.GetCurrentProcess().ProcessName;
            if (!EventLog.SourceExists(processName))
            {
                var eventSourceData = new EventSourceCreationData(processName, LogName);
                EventLog.CreateEventSource(eventSourceData);
            }

            EventLog Log = new EventLog();
            Log.Source = processName;

            Log.WriteEntry(message, level.ToEventLogEntryType());
        }
    }
}
