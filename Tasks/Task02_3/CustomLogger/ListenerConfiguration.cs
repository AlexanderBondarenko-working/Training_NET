using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLogger
{
    public class ListenerConfiguration
    {
        public string assemblyName;
        public string logName;
        
        public ListenerConfiguration(string assemblyName, string logName)
        {
            this.assemblyName = assemblyName;
            this.logName = logName;
        }
    }
}
