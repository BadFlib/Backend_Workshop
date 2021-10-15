using MVVM_WPF_Parser.ViewModels.Base;
using System.Collections.Generic;

namespace MVVM_WPF_Parser.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        private string _label = "Введите URL:";
        private string _url;
        private List<string> _uniqueWordCountStatistics;


        #region Свойства
        #region Заголовок поля ввода
        public string Label
        {
            get => _label;
            set => Set(ref _label, Label);
        }
        #endregion

        #region Поле ввода URL
        public string Url
        {
            get => _url;
            set => Set(ref _url, Url);
        }
        #endregion

        #region Статистика по количеству уникальных слов
        public List<string> UniqueWordCountStatistics { get; private set; }
        #endregion

        #endregion
            
    }
}
