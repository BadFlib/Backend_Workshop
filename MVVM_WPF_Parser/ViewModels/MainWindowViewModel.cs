using MVVM_WPF_Parser.ViewModels.Base;

namespace MVVM_WPF_Parser.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public string Label
        {
            get => _label;
            set => Set(ref _label, Label);
        }

        private string _label = "Введите URL:";
    }
}
