using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public new IEnumerator<Book> GetEnumerator()
        {
            var sortedItems = new List<Book>(Items);
            sortedItems.Sort();
            return sortedItems.GetEnumerator();
        }

        public List<Book> GetBooksByAuthor(string name, string surname)
        {
            return this.Where(book => book.Authors.Any(author => string.Equals(author.Name, name, StringComparison.OrdinalIgnoreCase) 
            && string.Equals(author.Surname, surname, StringComparison.OrdinalIgnoreCase))).ToList();
        }

        public List<Book> GetBooksSortedByDate()
        {
            return this.OrderByDescending(book => book.Date).ToList();
        }

        public (Author, int) GetAuthorsWithBooksAmount()
        {
            throw new NotImplementedException();
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
