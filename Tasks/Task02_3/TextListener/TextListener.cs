using System;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics;

namespace TextListener
{
    public class TextListener : CustomLogger.IListener
    {
        string logName = $"{Process.GetCurrentProcess().ProcessName}.txt";
        public string LogName { get => logName; set => logName = $"{value}.txt"; }

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
