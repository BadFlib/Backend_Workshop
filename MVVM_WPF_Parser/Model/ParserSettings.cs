using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_WPF_Parser.Model
{
    class ParserSettings
    {
        public readonly char[] Symbols = {',', ' ', '(', ')', '{', '}', '"', '_', '!',
                '?', '\\', '/', '<', '>', ':', ';', '\n', '\r', '\t', '0', '1', '2', '3',
                '4', '5', '6', '7', '8', '9', '.', '\'', '[', ']', '|', '»', '«', '$', '&', '*', '@'};

        public readonly string[] ServicePartsOfSpeech = {"без", "в", "во", "до", "за", "из", "к", "ко",
                "на", "над", "не", "о", "об", "обо", "от", "по", "под", "при", "про", "с", "а", "аж", "да", "ж", "же", "зато", "и",
                "или", "ибо", "кабы", "как", "ли", "ни", "но", "раз", "то", "чем", "что", "со", "для"};

    }
}
