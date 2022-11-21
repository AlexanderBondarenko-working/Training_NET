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

        public int? top;
        public int? left;
        public int? right;
        public int? bottom;

        public string title = string.Empty;

        public Window(XElement window)
        {
            title = window.Attribute(WindowTitleAttribute).Value;
            


            { window.Attribute(WindowTitleAttribute).Value} (" +
                            $"{window.Element(TopElementName)?.Value ?? "?"}," +
                            $"{window.Element(LeftElementName)?.Value ?? "?"}," +
                            $"{window.Element(WidthElementName)?.Value ?? "?"}," +
                            $"{window.Element(HeightElementName)?.Value ?? "?"})");
        }

        public override string ToString()
        {
            return $"{title}({top ?? '?'}, {left ?? '?'}, {right ?? '?'}, {bottom ?? '?'})";
        }
    }
}
