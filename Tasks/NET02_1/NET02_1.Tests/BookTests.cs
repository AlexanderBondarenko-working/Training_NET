using NUnit.Framework;
using System;

namespace NET02_1.Tests
{
    [TestFixture]
    public class BookTests
    {

        static string tooLongString = new String('a', 1001);

        static object[] IncorrectTitles =
        {
            new String('a', 1001),
            String.Empty
        };

        static object[] HappyPathInputData =
        {
            new object[] {"a", "1234567890123"},
            new object[] {new String('a', 1000), "1234567890123"},
            new object[] { "abc", "123-4-56-789012-3" }
        };

        [Test]
        [TestCaseSource(nameof(IncorrectTitles))]
        public void BookConstructor_CallWithIncorrectTitleLength_ExceptionThrown(string inputData)
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { var book = new Book(inputData, "1234567890123"); });
        }

        [Test]
        [TestCase("a345678B90123")]
        [TestCase("134567890123")]
        [TestCase("134-56789012-3")]
        public void BookConstructor_CallWithIncorrectISBN_ExceptionThrown(string inputData)
        {
            Assert.Throws(typeof(FormatException), () => { var book = new Book("aaa", inputData); });
        }

        [Test]
        [TestCaseSource(nameof(HappyPathInputData))]
        public void BookConstructor_HappyPathTest(string title, string ISBN)
        {
            Assert.DoesNotThrow(() => { var book = new Book(title, ISBN); });
        }
    }
}