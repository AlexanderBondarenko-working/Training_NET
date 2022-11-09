using System;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics;
using System.IO;

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
            using (StreamWriter logFile = new StreamWriter(LogName, true))
            {
                logFile.WriteLine($"{DateTime.Now}|{level}|{message}");
            }
        }
    }
}
