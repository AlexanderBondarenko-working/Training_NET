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
        public Configuration(XDocument document)
        {
            logins.AddRange(document.Root.Elements(LoginElementName).Select(loginInfo => new Login(loginInfo)));
        }

        public List<Login> logins = new List<Login>();

        public override string ToString()
        {
            return String.Concat(logins.Select(login => $"{login}\n"));
        }
    }
}
