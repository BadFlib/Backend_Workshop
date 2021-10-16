using MVVM_WPF_Parser.Model;
using MVVM_WPF_Parser.Model.Commands;
using MVVM_WPF_Parser.ViewModels.Base;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Input;

namespace MVVM_WPF_Parser.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        private string _label = "Введите URL:";
        private string _url;
        private List<string> _uniqueWordCountStatistics;
        private Parser _parser;


        #region Свойства
        #region Заголовок поля ввода
        public string Label
        {
            get => _label;
            set => Set(ref _label, value);
        }
        #endregion

        #region Поле ввода URL
        public string Url
        {
            get => _url;
            set => Set(ref _url, value);
        }
        #endregion

        #region Статистика по количеству уникальных слов
        public List<string> UniqueWordCountStatistics
        {
            get => _uniqueWordCountStatistics;
            set => Set(ref _uniqueWordCountStatistics, value);
        }
        #endregion

        #endregion

        #region Команды

        #region Старт
        public ICommand StartCommand { get; }
        #endregion

        #endregion

        private static bool CanStartCommandExecute(object p) => true;
        private void OnStartCommandExecuted(object p)
        {
            if (_url != null && !_url.Contains("http"))
            {
                _url = $"https://{Url}";
            }
            try
            {
                _parser = new Parser(_url);
                UniqueWordCountStatistics = _parser.GetListWithStatistics();
            }
            catch
            {
                MessageBox.Show($"Введен некорректный адрес: \n {Url}");
            }
            
        }

        public MainWindowViewModel()
        {
            StartCommand = new LambdaCommand(OnStartCommandExecuted, CanStartCommandExecute);
        }
    }
}