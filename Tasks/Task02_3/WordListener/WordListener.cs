using System;
using System.Diagnostics;

namespace WordListener
{
    public class WordListener : CustomLogger.IListener
    {
        string logName = $"{Process.GetCurrentProcess().ProcessName}.docx";
        public string LogName { get => logName; set => logName = $"{value}.docx"; }

        public void Write(object obj)
        {
            throw new NotImplementedException();
        }

        public void Write(string message, LoggingLevel level)
        {
            throw new NotImplementedException();
        }
    }
}
