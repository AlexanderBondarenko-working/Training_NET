using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace NET02_1
{
    public class Catalog : IEnumerable
    {
        List<Book> _Books = new List<Book>();

        public Catalog(List<Book> books)
        {
            if (books.Count != books.Distinct().Count())
            {
                throw new ArgumentException();
            }
            _Books.AddRange(books);
        }

        public void Add(Book value)
        {
            if (_Books.Contains(value))
            {
                throw new ArgumentException();
            }
            _Books.Add(value);
        }

        public bool ContainsKey(string key)
        {
            return _Books.Exists(book => book.ISBN.Equals(key.Replace("-", "")));
        }

        public bool Remove(string key)
        {
            return _Books.Remove(_Books.Find(book => book.ISBN.Equals(key.Replace("-", ""))));
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out Book value)
        {
            value = _Books.Find(book => book.ISBN.Equals(key.Replace("-", "")));
            return value != null;
        }

        public IEnumerator GetEnumerator()
        {
            return _Books.OrderByDescending(book => book.Title).GetEnumerator();

        }

        public List<Book> GetBooksByAuthor(string firstName, string lastName)
        {
            return _Books.Where(book => book.Authors.Any(author => string.Equals(author.FirstName, firstName, StringComparison.OrdinalIgnoreCase)
            && string.Equals(author.LastName, lastName, StringComparison.OrdinalIgnoreCase))).ToList();
        }

        public List<Book> GetBooksSortedByDate()
        {
            return _Books.OrderByDescending(book => book.Date).ToList();
        }

        public List<(Author, int)> GetAuthorsWithBooksAmount()
        {
            return _Books.SelectMany(book => book.Authors).Distinct().Select(author => (author, GetBooksByAuthor(author.FirstName, author.LastName).Count())).ToList();
        }

    }
}
