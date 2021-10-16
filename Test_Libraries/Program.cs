using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_Libraries
{
    class Program
    {

        private static readonly char[] _symbols = {',', ' ', '(', ')', '{', '}', '"', '_', '-', '!',
                '?', '\\', '/', '<', '>', ':', ';', '\n', '\r', '\t', '0', '1', '2', '3',
                '4', '5', '6', '7', '8', '9', '.', '\'', '[', ']', '|', '»', '«', '$', '&'};

        private static readonly string[] _servicePartsOfSpeech = {"без", "в", "во", "до", "за", "из", "к", "ко",
                "на", "над", "не", "о", "об", "обо", "от", "по", "под", "при", "про", "с", "а", "аж", "да", "ж", "же", "зато", "и",
                "или", "ибо", "кабы", "как", "ли", "ни", "но", "раз", "то", "чем", "что", "со", "для"};

        private const string URL = "https://simbirsoft.com";
        static void Main(string[] args)
        {
            var text = LoadText(URL);
            //Console.WriteLine(text);
            var words = GetWordsList(text);
            var uniqueWords = CountingUniqueWords(words);
            foreach (var key in uniqueWords.Keys)
            {
                Console.WriteLine($"{key} - {uniqueWords[key]}");
            }
        }

        private static string LoadText(string URL)
        {
            //var config = Configuration.Default.WithDefaultLoader();
            //var document = BrowsingContext.New(config).OpenAsync(URL).Result;
            //var scripts = document.QuerySelectorAll("script");
            //foreach (var script in scripts)
            //{
            //    script.Remove();
            //}
            //var text = document.QuerySelector("body").TextContent;
            //return text.ToUpper();
            var web = new HtmlWeb();
            var doc = web.Load(URL);
            var text = doc.DocumentNode.InnerText.ToUpper();
            return text;
        }

        static private List<string> GetWordsList(string text)
        {
            var Words = new List<string>();
            foreach (var word in text.Split(_symbols))
            {
                if (!string.IsNullOrEmpty(word) && !_servicePartsOfSpeech.ToList().Contains(word.ToLower()) && word.Length > 1)
                {
                    Words.Add(word);
                }
            }
            return Words;
        }
        static private Dictionary<string, int> CountingUniqueWords(List<string> Words)
        {
            var UniqueWords = new Dictionary<string, int>();
            foreach (var word in Words)
            {
                if (UniqueWords.ContainsKey(word))
                {
                    UniqueWords[word]++;
                }
                else
                {
                    UniqueWords.Add(word, 1);
                }
            }
            return UniqueWords;
        }
        static private List<string> GetListWithStatistics(Dictionary<string, int> UniqueWords)
        {
            var ListWithStatistics = new List<string>();
            foreach (var key in UniqueWords.Keys)
            {
                ListWithStatistics.Add($"{key} - {UniqueWords[key]}");
            }
            return ListWithStatistics;
        }
    }
}
