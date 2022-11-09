using System;

namespace CustomLogger
{
    public interface IListener
    {
        public string LogName { get; set; }

        public void Write(string message, LoggingLevel level);

        public void Write(object obj);
    }
}
