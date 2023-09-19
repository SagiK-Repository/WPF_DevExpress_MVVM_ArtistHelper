using ArtistHelper.Common;
using ArtistHelper.View;
using ArtistHelper.ViewModel;
using DevExpress.Mvvm;
using DevExpress.Xpf.Docking;

namespace ArtistHelper.Model
{
    public class PanelModel : ViewModelBase, IMVVMDockingProperties
    {
        public string Caption { get; set; }
        public DrawView DrawViews
        {
            get { return GetProperty(() => DrawViews); }
            set { SetProperty(() => DrawViews, value); }
        }
        public DrawViewModel DrawViewModels
        {
            get { return GetProperty(() => DrawViewModels); }
            set { SetProperty(() => DrawViewModels, value); }
        }

        public string TargetName { get; set; }

        #region 생성자
        public PanelModel()
        {
            _initialize();
        }
        void _initialize()
        {
            var artistModel = ArtistHelperDataBase.GetDefaultArtistModel();

            DrawViewModels = new DrawViewModel(artistModel);
            DrawViews = new DrawView(DrawViewModels);
        }
        #endregion

        #region Method
        public void Update(ArtistModel<double> artist)
        {
            DrawViewModels.Update(artist);
        }
        #endregion
    }
}
