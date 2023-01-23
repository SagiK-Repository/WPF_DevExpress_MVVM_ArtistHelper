using ArtistHelper.View;
using ArtistHelper.ViewModel;
using System.Windows;

namespace ArtistHelper
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainViewModel mainViewModel = new MainViewModel();
            MainView mainView = new MainView(mainViewModel);

            mainView.Show();

        }
    }
}
