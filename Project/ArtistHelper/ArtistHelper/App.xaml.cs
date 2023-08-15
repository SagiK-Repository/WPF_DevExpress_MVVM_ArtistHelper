using ArtistHelper.Common;
using ArtistHelper.Model;
using ArtistHelper.View;
using ArtistHelper.ViewModel;
using System;
using System.Collections.ObjectModel;
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

            _logger.LogSecond("Initiallize", () => Initiallize());
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
        private void Initiallize()
        {
            ArtistHelperDataBase.ViewPanelName = "NewDraw";
            ArtistHelperDataBase.PanelModels = new ObservableCollection<PanelModel>();
            ArtistHelperDataBase.PanelModels.Add(new PanelModel() { Caption = "NewDraw" });
        }
    }
}
