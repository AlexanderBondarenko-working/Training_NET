using System;
using System.Collections.Generic;
using System.Text;

namespace Task01_1
{
    public class TextMaterial : TrainingMaterial
    {
        public static int maxContentSize = 10_000;
        public string TextContent { get; private set; }

        public TextMaterial(string textContent)
        {
            if (string.IsNullOrEmpty(textContent))
            {
                throw new ArgumentException("Content is null or empty!");
            }
            else if(textContent.Length > maxContentSize)
            {
                throw new ArgumentOutOfRangeException($"The content size should be less than {maxContentSize} characters!");
            }
            TextContent = textContent;
        }

        public override string ToString()
        {
            return "TextMaterial: " + TextContent;
        }
    }
}
