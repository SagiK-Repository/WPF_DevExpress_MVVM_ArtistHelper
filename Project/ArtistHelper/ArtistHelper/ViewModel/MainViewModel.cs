using ArtistHelper.View;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistHelper.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region 변수
        #endregion
        
        #region 프로퍼티
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
            Initialize();
        }
        #endregion

        #region 메소드
        void Initialize()
        {
            RibbonViewModels = new RibbonViewModel();
            RibbonViews = new RibbonView(RibbonViewModels);

            PanelViewModels = new PanelViewModel();
            PanelViews = new PanelView(PanelViewModels);
        }
        #endregion
    }
}
