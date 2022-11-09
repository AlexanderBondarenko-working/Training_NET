using System;

namespace EventLogListener
{
    public class EventLogListener : CustomLogger.IListener
    {
        public string LogName { get; set; }

        public void Write(object obj)
        {
            throw new NotImplementedException();
        }

        public void Write(string message, LoggingLevel level)
        {
            //throw new NotImplementedException();
        }
    }
}
