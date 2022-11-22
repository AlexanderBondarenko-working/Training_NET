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
        

        public string Name { get; set; } = string.Empty;
        public List<Window> Windows { get; set; } = new List<Window>();

        public Login(XElement login)
        {
            Name = login.Attribute(LoginAttributeName).Value;
            Windows.AddRange(login.Elements(WindowElementName).Select(windowElement => new Window(windowElement)));
        }

        public bool IsLoginConfigsCorrect()
        {
            return !Windows.Any(window => window.Title == Window.MainWindowTitle) || 
                (Windows.Where(window => window.Title == Window.MainWindowTitle).Count() == 1 && 
                Windows.Any(window => window.Title == Window.MainWindowTitle && window.IsFullyConfigured()));
        }

        public override string ToString()
        {
            return $"Login: {Name} {(Windows.Count != 0 ? string.Concat(Windows.Select((window) => $"\n\t{window}")) : "\n\t...") }";
        }
    }
}
