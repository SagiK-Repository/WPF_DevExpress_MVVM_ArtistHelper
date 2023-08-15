using ArtistHelper.View;
using ArtistHelper.ViewModel;
using System;
using System.Windows;
using Utility.LogService;

namespace ArtistHelper
{
    public partial class App : Application
    {
        private Logger _logger;

        public App()
        {
            _logger = new Logger(NLog.LogManager.GetCurrentClassLogger());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _logger.TryCatchLogSecond("OnStartup... - Show MainView", () =>
            {
                MainViewModel mainViewModel = new MainViewModel();
                MainView mainView = new MainView(mainViewModel);

                mainView.Show();
            });
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _logger.DebugAction("Exit", () =>
            {
                Environment.Exit(0);
            });
        }
    }
}
