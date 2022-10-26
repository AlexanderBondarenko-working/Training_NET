using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NET02_1
{
    public class Author
    {
        public const string LengthPattern = @"^.{1,200}$";

        public string Name { get; private set; }
        public string Surname { get; private set; }

        public Author(string name, string surname)
        {
            if (!Regex.IsMatch(name, LengthPattern) || !Regex.IsMatch(surname, LengthPattern))
            {
                throw new ArgumentOutOfRangeException();
            }

            Name = name;
            Surname = surname;
        }
    }
}
