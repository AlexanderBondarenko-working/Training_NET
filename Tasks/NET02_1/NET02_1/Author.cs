using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace NET02_1
{
    public class Author
    {
        public readonly string LengthPattern = @"^.{1,200}$";

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Author(string firstName, string lastName)
        {
            if (!Regex.IsMatch(firstName, LengthPattern) || !Regex.IsMatch(lastName, LengthPattern))
            {
                throw new ArgumentOutOfRangeException();
            }

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            FirstName = textInfo.ToTitleCase(firstName);
            LastName = textInfo.ToTitleCase(lastName);
        }

    }
}
