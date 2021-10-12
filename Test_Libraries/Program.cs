using HtmlAgilityPack;
using System;

namespace Test_Libraries
{
    class Program
    {
        public const string URL = "https://simbirsoft.com";
        static void Main(string[] args)
        {
            HtmlAgilityPack_test(URL);
        }

        static private void AngleSharp_test(string URL)
        {

        }

        static private void HtmlAgilityPack_test(string URL)
        {
            var web = new HtmlWeb();
            var doc = web.Load(URL);
            var text = doc.DocumentNode.InnerText;
            Console.WriteLine(text);
            Console.ReadLine();
        }
    }
}
