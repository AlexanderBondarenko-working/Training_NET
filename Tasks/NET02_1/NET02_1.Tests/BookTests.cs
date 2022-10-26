using NUnit.Framework;
using System;
using NET02_1;

namespace NET02_1.Tests
{
    [TestFixture]
    public class BookTests
    {

        [Test]
        public void BookConstructor_CallWithIncorrectTitleLength_ExceptionThrown()
        {
            //empty title 
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { var book = new Book("", "1234567890123"); });

            //title length more than 1000 characters
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { var book = new Book(new String('a', 1001), "1234567890123"); });
        }

        [Test]
        public void BookConstructor_CallWithIncorrectISBN_ExceptionThrown()
        {
            //ISBN contains letters
            Assert.Throws(typeof(FormatException), () => { var book = new Book("aaa", "a345678B90123"); });

            //ISBN length
            Assert.Throws(typeof(FormatException), () => { var book = new Book("aaa", "134567890123"); });

            //ISBN part of dashes
            Assert.Throws(typeof(FormatException), () => { var book = new Book("aaa", "134-56789012-3"); });
        }

        [Test]
        public void BookConstructor_HappyPathTest()
        {
            //the shortest title
            Assert.DoesNotThrow(() => { var book = new Book("a", "1234567890123"); });

            //the longest title
            Assert.DoesNotThrow(() => { var book = new Book(new String('a', 1000), "1234567890123"); });

            //ISBN with dashes
            Assert.DoesNotThrow(() => { var book = new Book("abc", "123-4-56-789012-3"); });
        }
    }
}