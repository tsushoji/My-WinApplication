using System.Windows;
using TsuShoWinApp.MainWindow;

namespace TsuShoWinApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindowView = new MainWindowView();
            mainWindowView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mainWindowView.Top = 0;
            mainWindowView.ShowDialog();
        }
    }
}
