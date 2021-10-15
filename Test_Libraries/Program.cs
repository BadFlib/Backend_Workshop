using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_Libraries
{
    class Program
    {
        private const string URL = "https://simbirsoft.com";
        private static string _words;
        private static readonly char[] _symbols = {',', ' ', '(', ')', '{', '}', '"', '_', '-', '!',
                '?', '\\', '/', '<', '>', ':', ';', '\n', '\r', '\t', '0', '1', '2', '3',
                '4', '5', '6', '7', '8', '9', '.', '\'', '[', ']', '|', '»', '«', '$', '&'};
        private static string[] _servicePartsOfSpeech = {"без", "в", "во", "до", "за", "из", "к", "ко",
                "на", "над", "не", "о", "об", "обо", "от", "по", "под", "при", "про", "с", "а", "аж", "да", "ж", "же", "зато", "и",
                "или", "ибо", "кабы", "как", "ли", "ни", "но", "раз", "то", "чем", "что", "со", "для"};
        static void Main(string[] args)
        {
            var text = LoadText(URL);
            var words = GetWordsList(text);
            var uniqueWords = CountingUniqueWords(words);
            foreach (var key in uniqueWords.Keys)
            {
                Console.WriteLine($"{key} - {uniqueWords[key]}");
            }
        }

        static private string LoadText(string URL)
        {
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
    }
}
