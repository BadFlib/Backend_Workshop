using HtmlAgilityPack;

namespace MVVM_WPF_Parser.Model
{
    class TextLoader
    {
        private readonly HtmlWeb _Client;
        private readonly string _Url;

        public TextLoader(string Url)
        {
            _Client = new HtmlWeb();
            _Url = Url;
        }

        public string LoadText()
        {
            if (_Url == null) return null;
            var HtmlDocument = _Client.Load(_Url);
            var Html = HtmlDocument.DocumentNode.InnerHtml.Replace("<", " <");
            HtmlDocument.LoadHtml(Html);
            string text = HtmlDocument.DocumentNode.InnerText.ToUpper();
            return text;
        }
    }
}
