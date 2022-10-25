using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;

namespace NET02_1
{
    class Book : IComparable<Book>
    {
        public const string PatternISBN = @"\d{13}";
        public const string DashPatternISBN = @"\d{3}-\d-\d{2}-\d{6}-\d{1}";
        public const string LengthPatternTitle = @"\w{1,1000}";

        public string Title { get; private set; }
        public string ISBN { get; private set; }
        public DateTime Date { get; set; } = default;
        List<Author> Authors { get; } = new List<Author>();

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
            this.ISBN = ISBN;
            Title = title;
        }

        public override bool Equals(object obj)
        {
            if (obj is Book book)
            {
                return Regex.Replace(this.ISBN, "-", "").Equals(Regex.Replace(book.ISBN, "-", ""));
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo([AllowNull] Book other)
        {
            if (other is null)
                throw new ArgumentNullException();
            return this.Title.CompareTo(other.Title);
        }
    }
}
