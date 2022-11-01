using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Task02_2
{
    public static class ConfigurationHelper
    {
        public static readonly string LoginElementName = "login";
        public static readonly string LoginNameAttribute = "name";
        public static readonly string WindowElementName = "window";
        public static readonly string WindowTitleAttribute = "title";
        public static readonly string TopElementName = "top";
        public static readonly string LeftElementName = "left";
        public static readonly string WidthElementName = "width";
        public static readonly string HeightElementName = "height";

        public static string LoginsToString(this IEnumerable<XElement> logins)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var login in logins)
            {
                sb.AppendLine($"{login.Name}: {login.Attribute(LoginNameAttribute).Value}");
                var windws = login.Elements(WindowElementName);
                if (windws.Any())
                {
                    foreach (var window in windws)
                    {
                        sb.AppendLine($"    {window.Attribute(WindowTitleAttribute).Value}(" +
                            $"{window.Element(TopElementName)?.Value ?? "?"}," +
                            $"{window.Element(LeftElementName)?.Value ?? "?"}," +
                            $"{window.Element(WidthElementName)?.Value ?? "?"}," +
                            $"{window.Element(HeightElementName)?.Value ?? "?"})");
                    }
                }
                else
                {
                    sb.AppendLine(login.Value);
                }
            }
            return sb.ToString();
        }

        public static bool IsLoginCorrect(this XElement login)
        {
            var mainElements = login.Elements(WindowElementName).Where(element => element.Attribute(WindowTitleAttribute).Value == "main");
            if (mainElements.Count() <= 1)
            {
                var mainElement = mainElements.FirstOrDefault();
                return mainElement == null ? true : 
                    mainElement.Element(TopElementName) != null &&
                    mainElement.Element(LeftElementName) != null &&
                    mainElement.Element(WidthElementName) != null &&
                    mainElement.Element(HeightElementName) != null;
            }
            return false;
        }

        public static IEnumerable<XElement> Logins(this XDocument document)
        {
            return document.Root.Elements(LoginElementName);
        }
    }
}
