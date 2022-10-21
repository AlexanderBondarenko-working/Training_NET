using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NET02_1
{
    class Book
    {
        [Required]
        [StringLength(1, MinimumLength = 1000)]
        public string Title { get; private set; }

        [RegularExpression(@"\d{3}-?\d-?\d{2}-?\d{6}-?\d{1}")]
        public string ISBN { get; private set; }

        public DateTime Date;

        List<Author> authors;

        public Book(string title)
        {
            Title = title;
        }
    }
}
