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

            Console.Write(document.Logins().LoginsToString());

            Console.Write(document.Logins().Where(login => login.IsLoginCorrect()).LoginsToString());
        }
    }
}
