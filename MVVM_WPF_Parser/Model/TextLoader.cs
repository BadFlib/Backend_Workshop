using HtmlAgilityPack;

namespace MVVM_WPF_Parser.Model
{
    class TextLoader
    {
        private readonly HtmlWeb client;
        private readonly string _url;

        public TextLoader(string url)
        {
            client = new HtmlWeb();
            _url = url;
        }

        public string LoadText()
        {
            var HtmlDocument = client.Load(_url);
            var text = HtmlDocument.DocumentNode.InnerText.ToUpper();
            return text;
        }
    }
}
