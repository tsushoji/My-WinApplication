using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TsuShoWinApp.AbceedVocabularyAppend;
using TsuShoWinApp.Home;
using TsuShoWinApp.InstagramMedia;
using TsuShoWinApp.StartUp;

namespace TsuShoWinApp.MainWindow
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel() 
        {
            _selectedViewModel = new StartUpViewModel();
            _menucommand = new RelayCommand(param => SwitchViews(param));
            _closeAppCommand = new RelayCommand(p => CloseApp(p));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private object _selectedViewModel;
        public object SelectedViewModel
        {
            get => _selectedViewModel;
            set { _selectedViewModel = value; OnPropertyChanged(); }
        }

        public void SwitchViews(object parameter)
        {
            switch (parameter)
            {
                case "ホーム":
                    SelectedViewModel = new HomeViewModel();
                    break;
                case "Instagram情報取得":
                    SelectedViewModel = new InstagramMediaViewModel();
                    break;
                case "abceed単語帳追加":
                    SelectedViewModel = new AbceedVocabularyAppendViewModel();
                    break;
                default:
                    SelectedViewModel = new HomeViewModel();
                    break;
            }
        }

        private ICommand _menucommand;
        public ICommand MenuCommand
        {
            get
            {
                return _menucommand;
            }
        }

        public void CloseApp(object obj)
        {
            MainWindowView? win = obj as MainWindowView;
            win?.Close();
        }

        // Close App Command
        private ICommand _closeAppCommand;
        public ICommand CloseAppCommand
        {
            get
            {
                return _closeAppCommand;
            }
        }
    }
}
