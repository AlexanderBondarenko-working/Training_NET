using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;

namespace NET02_1
{
    class Catalog : KeyedCollection<string, Book>
    {
        public Catalog() : base(new ISBNEqualityComparer()) { }
        protected override string GetKeyForItem(Book item)
        {
            return item.ISBN;
        }
    }

    class ISBNEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string ISBN1, string ISBN2)
        {
            return Regex.Replace(ISBN1, "-", "").Equals(Regex.Replace(ISBN2, "-", ""));
        }

        public int GetHashCode(string ISBN)
        {
            return Regex.Replace(ISBN, "-", "").GetHashCode();
        }
    }
}
