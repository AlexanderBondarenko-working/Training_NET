using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLogger
{
    public class LoggerConfigurations
    {
        public LoggingLevel MinLoggingLevel { get; private set; }
        public List<string> AssemblyNames;
    }
}
