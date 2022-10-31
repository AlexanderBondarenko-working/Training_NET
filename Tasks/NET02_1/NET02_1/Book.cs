using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NET02_1
{
    public class Book
    {
        public readonly string PatternISBN = @"\d{13}";
        public readonly string DashPatternISBN = @"\d{3}-\d-\d{2}-\d{6}-\d{1}";
        public readonly string LengthPatternTitle = @"^.{1,1000}$";

        public string Title { get; private set; }
        public string ISBN { get; private set; }
        public DateTime Date { get; set; } = default;
        public List<Author> Authors { get; } = new List<Author>();

        public Book(string title, string ISBN)
        {
            if (!Regex.IsMatch(title, LengthPatternTitle))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (!Regex.IsMatch(ISBN, PatternISBN) && !Regex.IsMatch(ISBN, DashPatternISBN))
            {
                throw new FormatException();
            }
            this.ISBN = Regex.Replace(ISBN, "-", "");
            Title = title;
        }

        public Book(string title, string ISBN, List<Author> authors) : this(title, ISBN) => Authors.AddRange(authors);

        public override bool Equals(object obj)
        {
            if (obj is Book book)
            {
                return this.ISBN.Equals(book.ISBN);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
