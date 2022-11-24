using System;
using System.Diagnostics;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using System.IO;
using DocumentFormat.OpenXml;

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
            using WordprocessingDocument wordDocument = File.Exists(LogName) ? WordprocessingDocument.Open(LogName, true) : CreateWordprocessingDocument(LogName);
            
            Body body = wordDocument.MainDocumentPart.Document.Body;
            Paragraph para = body.AppendChild(new Paragraph());
            Run run = para.AppendChild(new Run());
            run.AppendChild(new Text($"{DateTime.Now}|{level}|{message}"));
        }

        public static WordprocessingDocument CreateWordprocessingDocument(string filepath)
        {
            WordprocessingDocument wordDocument =
            WordprocessingDocument.Create(filepath, WordprocessingDocumentType.Document);
            MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
            mainPart.Document = new Document();
            mainPart.Document.AppendChild(new Body());
            return wordDocument;
        }
    }
}
