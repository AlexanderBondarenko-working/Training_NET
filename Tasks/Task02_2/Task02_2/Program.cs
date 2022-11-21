using System;
using System.Linq;
using System.Xml.Linq;

namespace Task02_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument document = XDocument.Load(@"..\..\..\Config\Data.xml");
            var configuration = new Configuration(document);

            Console.Write(configuration.ToString());
            Console.Write(String.Concat(configuration.logins.Where(login => login.IsLoginConfigsCorrect()).Select(CorrectLogin => $"{CorrectLogin.ToString()}\n")));
        }
    }
}
