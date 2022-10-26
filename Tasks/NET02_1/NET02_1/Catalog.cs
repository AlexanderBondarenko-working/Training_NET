using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NET02_1
{
    public class Catalog : KeyedCollection<string, Book>
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

        public List<(Author, int)> GetAuthorsWithBooksAmount()
        {
            return this.SelectMany(book => book.Authors).Distinct(new AutorEqualityComparer()).Select(author => (author, GetBooksByAuthor(author.Name, author.Surname).Count())).ToList();
        }

    }

    class ISBNEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string FirstISBN, string SecondISBN)
        {
            return Regex.Replace(FirstISBN, "-", "").Equals(Regex.Replace(SecondISBN, "-", ""));
        }

        public int GetHashCode(string ISBN)
        {
            return Regex.Replace(ISBN, "-", "").GetHashCode();
        }
    }

    class AutorEqualityComparer : IEqualityComparer<Author>
    {
        public bool Equals(Author FirstAuthor, Author SecondAuthor)
        {
            return string.Equals(FirstAuthor.Name, SecondAuthor.Name, StringComparison.OrdinalIgnoreCase)
            && string.Equals(FirstAuthor.Surname, SecondAuthor.Surname, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(Author author)
        {
            return (author.Name.ToUpper() + author.Surname.ToUpper()).GetHashCode();
        }
    }
}
