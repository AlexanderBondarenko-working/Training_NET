using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

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
            foreach(var name in loggerConfigurations.AssemblyNames)
            {
                var assemblyName = new AssemblyName(name);
                Assembly assembly = Assembly.Load(assemblyName);
                listeners.Add((IListener)Activator.CreateInstance(assembly.GetType("IListener")));
            }
        }

        public void Debug(string info)
        {

        }

        public void Info(string info)
        {

        }

        public void Warning(string info)
        {

        }

        public void Error(string info)
        {

        }

        public void Fatal(string info)
        {

        }


        public void Track(object obj)
        {

        }
    }
}
