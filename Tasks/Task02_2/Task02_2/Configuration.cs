using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XMLConfiguration;

namespace Task02_2
{
    public class Configuration
    {
        public static readonly string LoginElementName = "login";

        public List<Login> Logins { get; set; } = new List<Login>();

        public Configuration(XDocument document)
        {
            Logins.AddRange(document.Root.Elements(LoginElementName).Select(loginInfo => new Login(loginInfo)));
        }

        public override string ToString()
        {
            return String.Concat(Logins.Select(login => $"{login}\n"));
        }
    }
}
