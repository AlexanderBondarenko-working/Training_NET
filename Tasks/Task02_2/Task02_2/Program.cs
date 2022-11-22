using System;
using System.Linq;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Task02_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument document = XDocument.Load(@"..\..\..\Config\Data.xml");
            var configuration = new Configuration(document);

            Console.Write(configuration.ToString());
            Console.Write(String.Concat(configuration.Logins.Where(login => login.IsLoginConfigsCorrect()).Select(CorrectLogin => $"{CorrectLogin.ToString()}\n")));
            
            foreach(var login in configuration.Logins)
            {
                login.Windows.ForEach(window => window.ExpandConfiguratuons());
                string jsonString = JsonSerializer.Serialize<Login>(login, new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(@$"..\..\..\Config\{login.Name}.json", jsonString);
                Console.WriteLine(jsonString);
            }
        }
    }
}
