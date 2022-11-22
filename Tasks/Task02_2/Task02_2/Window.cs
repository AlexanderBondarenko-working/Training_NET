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

        public string Title { get; set; } = string.Empty;

        public int? Top { get; set; }
        public int? Reft { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }

        public Window(XElement window)
        {
            Title = window.Attribute(WindowTitleAttribute).Value;

            Top = GetElementByName(TopElementName, window);
            Reft = GetElementByName(LeftElementName, window);
            Width = GetElementByName(WidthElementName, window);
            Height = GetElementByName(HeightElementName, window);
        }

        public bool IsFullyConfigured()
        {
            return Top != null && Reft != null && Width != null && Height != null;
        }

        public override string ToString()
        {
            return $"{Title}({Top ?? '?'}, {Reft ?? '?'}, {Width ?? '?'}, {Height ?? '?'})";
        }

        public void ExpandConfiguratuons()
        {
            Top = Top ?? 0;
            Reft = Reft ?? 0;
            Width = Width ?? 400;
            Height ??= 150;
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
