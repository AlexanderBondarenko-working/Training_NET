using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Task02_2
{
    public class Window
    {
        public static readonly string WindowTitleAttribute = "title";
        public static readonly string TopElementName = "top";
        public static readonly string LeftElementName = "left";
        public static readonly string WidthElementName = "width";
        public static readonly string HeightElementName = "height";
        public static readonly string MainWindowTitle = "main";

        public int? top;
        public int? left;
        public int? width;
        public int? height;

        public string title = string.Empty;

        public Window(XElement window)
        {
            title = window.Attribute(WindowTitleAttribute).Value;

            top = GetElementByName(TopElementName, window);
            left = GetElementByName(LeftElementName, window);
            width = GetElementByName(WidthElementName, window);
            height = GetElementByName(HeightElementName, window);
        }

        public bool IsFullyConfigured()
        {
            return top != null && left != null && width != null && height != null;
        }

        public override string ToString()
        {
            return $"{title}({top ?? '?'}, {left ?? '?'}, {width ?? '?'}, {height ?? '?'})";
        }

        int? GetElementByName(string name, XElement parentElement)
        {
            int? result = null;
            var value = parentElement.Element(name)?.Value;

            if (value != null && int.TryParse(value, out int parseResult))
            {
                result = parseResult;
            }

            return result;
        }
    }
}
