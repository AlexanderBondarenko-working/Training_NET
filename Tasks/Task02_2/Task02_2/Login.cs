using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Task02_2
{
    public class Login
    {
        public static readonly string LoginAttributeName = "name";
        public static readonly string WindowElementName = "window";
        

        public string name = string.Empty;
        public List<Window> windows = new List<Window>();

        public Login(XElement login)
        {
            name = login.Attribute(LoginAttributeName).Value;
            windows.AddRange(login.Elements(WindowElementName).Select(windowElement => new Window(windowElement)));
        }

        public bool IsLoginConfigsCorrect()
        {
            return !windows.Any(window => window.title == Window.MainWindowTitle) || 
                (windows.Where(window => window.title == Window.MainWindowTitle).Count() == 1 && 
                windows.Any(window => window.title == Window.MainWindowTitle && window.IsFullyConfigured()));
        }

        public override string ToString()
        {
            return $"Login: {name} {(windows.Count != 0 ? string.Concat(windows.Select((window) => $"\n\t{window}")) : "\n\t...") }";
        }
    }
}
