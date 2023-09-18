using ArtistHelper.Common;
using ArtistHelper.Model;
using ArtistHelper.View;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using Utility.LogService;

namespace ArtistHelper.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region 변수
        Logger _logger;
        #endregion

        #region Enum
        private enum _messengerType
        {
            NewPanel,
            SavePanel
        }
        #endregion

        #region 프로퍼티
        public ObservableCollection<PanelModel> PanelModels
        {
            get { return ArtistHelperDataBase.PanelModels; }
        }
        public RibbonView RibbonViews
        {
            get { return GetProperty(() => RibbonViews); }
            set { SetProperty(() => RibbonViews, value); }
        }
        public RibbonViewModel RibbonViewModels
        {
            get { return GetProperty(() => RibbonViewModels); }
            set { SetProperty(() => RibbonViewModels, value); }
        }
        public PanelView PanelViews
        {
            get { return GetProperty(() => PanelViews); }
            set { SetProperty(() => PanelViews, value); }
        }
        public PanelViewModel PanelViewModels
        {
            get { return GetProperty(() => PanelViewModels); }
            set { SetProperty(() => PanelViewModels, value); }
        }
        #endregion

        #region 생성자
        public MainViewModel()
        {
            _logger = new Logger(NLog.LogManager.GetCurrentClassLogger());

            _logger.LogSecond("Initiallize", () => _initiallize());
        }
        #endregion

        #region 메소드
        void _initiallize()
        {
            RibbonViewModels = new RibbonViewModel();
            RibbonViews = new RibbonView(RibbonViewModels);

            PanelViewModels = new PanelViewModel();
            PanelViews = new PanelView(PanelViewModels);

            Messenger.Default.Register<string>(this, OnMessage);
        }
        #endregion

        #region Messenger Method
        private void OnMessage(string text)
        {
        }
        #endregion
    }
}
