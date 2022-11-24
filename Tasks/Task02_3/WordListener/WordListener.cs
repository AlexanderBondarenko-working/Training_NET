using System;
using System.Diagnostics;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;


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
            WordprocessingDocument wordprocessingDocument =
            WordprocessingDocument.Open(logName, true);

            Body body = wordprocessingDocument.MainDocumentPart.Document.Body;
            body.Append(new Text($"{DateTime.Now}|{level}|{message}"));

            wordprocessingDocument.Close();
        }
    }
}
