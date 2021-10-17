using System.Collections.Generic;
using System.Linq;

namespace MVVM_WPF_Parser.Model
{
    class Parser
    {
        private readonly TextLoader _textLoader;
        private readonly string _text;
        private readonly ParserSettings _parserSettings;
        private readonly Dictionary<string, int> _uniqueWords;

        public Parser(string Url)
        {
            _textLoader = new TextLoader(Url);
            _parserSettings = new ParserSettings();
            _text = _textLoader.LoadText();
            _uniqueWords = CountingUniqueWords();
        }
        public List<string> GetListWithStatistics()
        {
            List<string> ListWithStatistics = new List<string>();
            if (_uniqueWords == null) return null;
            foreach (var key in _uniqueWords.Keys)
            {
                ListWithStatistics.Add($"{key} - {_uniqueWords[key]}");
            }
            return ListWithStatistics;
        }
        private List<string> GetWordsList()
        {
            var Words = new List<string>();
            if (_text == null) return null;
            foreach (var word in _text.Split(_parserSettings.Symbols))
            {
                if (!string.IsNullOrEmpty(word) && !_parserSettings.ServicePartsOfSpeech.ToList().Contains(word.ToLower()) && word.Length > 1)
                {
                    Words.Add(word);
                }
            }
            return Words;
        }
        private Dictionary<string, int> CountingUniqueWords()
        {
            List<string> Words = GetWordsList();
            Dictionary<string, int> UniqueWords = new Dictionary<string, int>();
            if (Words == null) return null;
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
