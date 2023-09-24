using ArtistHelper.Common;
using ArtistHelper.Model;
using ArtistHelper.View;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;
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
        private void OnMessage(string receiveMessage)
        {
            _logger.Info("Receive Messaged");
            _logger.TryCatchStartEndLog("Switch Message", () => _caseSwitch(receiveMessage));
        }
        #endregion

        #region private Method
        private void _caseSwitch(string receiveMessage)
        {
            if (receiveMessage.StartsWith("DockLayoutManagerEventsService -> MainViewModel : Docking Item Activating : "))
            {
                var panelName = receiveMessage.Substring("DockLayoutManagerEventsService -> MainViewModel : Docking Item Activating : ".Length);
                _setPanel(panelName);
            }
            else if (receiveMessage.StartsWith("DockLayoutManagerEventsService -> MainViewModel : Docking Closed : "))
            {
                var panelName = receiveMessage.Substring("DockLayoutManagerEventsService -> MainViewModel : Docking Closed : ".Length);
                _deletePanel(panelName);
            }
        }

        private void _setPanel(string panelName)
        {
            ArtistHelperDataBase.ViewPanelName = panelName;

            var panelModel = ArtistHelperDataBase.PanelModels.FirstOrDefault(x => x.Caption == panelName);
            if (panelModel != null)
                PanelViewModels.ArtistModels = panelModel.DrawViewModels.ArtistModels;
            else
                _logger.Error("Fail Set Panel, panelModel is null");
        }

        private void _deletePanel(string panelName)
        {
            var panelModel = ArtistHelperDataBase.PanelModels.FirstOrDefault(x => x.Caption == panelName);
            ArtistHelperDataBase.PanelModels.Remove(panelModel);
        } 
        #endregion
    }
}
