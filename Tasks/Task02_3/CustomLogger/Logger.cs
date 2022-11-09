using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger
{
    public class Logger
    {
        List<IListener> listeners = new List<IListener>();
        LoggerConfigurations loggerConfigurations;

        public Logger(LoggerConfigurations loggerConfigurations)
        {
            this.loggerConfigurations = loggerConfigurations;
            LoadAssemblies();
        }

        void LoadAssemblies()
        {
            foreach(var config in loggerConfigurations.ListenerConfigurations)
            {
                Assembly assembly;
                assembly = Assembly.LoadFrom(config.assemblyName);
                var listenerType = assembly.GetTypes().SingleOrDefault(x => x.GetInterfaces().Contains(typeof(IListener)));
                var listener = (IListener)Activator.CreateInstance(listenerType);
                listener.LogName = config.logName;
                listeners.Add(listener);
            }
        }

        public void Debug(string content)
        {
            if (loggerConfigurations.IsLoggingLevelAllowed(LoggingLevel.Debug))
            {
                WriteLog(content, LoggingLevel.Debug);
            }
        }

        public void Info(string content)
        {
            if (loggerConfigurations.IsLoggingLevelAllowed(LoggingLevel.Info))
            {
                WriteLog(content, LoggingLevel.Info);
            }
        }

        public void Warning(string content)
        {
            if (loggerConfigurations.IsLoggingLevelAllowed(LoggingLevel.Warning))
            {
                WriteLog(content, LoggingLevel.Warning);
            }
        }

        public void Error(string content)
        {
            if (loggerConfigurations.IsLoggingLevelAllowed(LoggingLevel.Error))
            {
                WriteLog(content, LoggingLevel.Error);
            }
        }

        public void Track(object obj)
        {

        }

        void WriteLog(string content, LoggingLevel level)
        {
            listeners.ForEach(listener => listener.Write(content, level));
        }
    }
}
