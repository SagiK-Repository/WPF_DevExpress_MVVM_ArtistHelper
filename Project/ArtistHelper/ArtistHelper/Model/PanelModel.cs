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
            var artistModel = new ArtistModel<double>()
            {
                Width = new Width<double>(10, 0, 1000),
                Height = new Height<double>(100, 0, 1000),
                LineGrid = new Grid<double>(10),
                MinWidth = new Width<double>(0, 0, 1000),
                MinHeight = new Height<double>(0, 0, 1000),
                EndPoint = new Point<double>(0, 0),
                BoxCount = new Count<double>(1, 0, 10)
            };

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
