using ArtistHelper.Interface;
using ArtistHelper.Model;
using ArtistHelper.Common.ShapeList;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace ArtistHelper.ViewModel
{
    public class DrawViewModel : ViewModelBase
    {
        IShape _shape;

        #region 프로퍼티
        public ArtistModel<double> ArtistModels { get; set; }
        public ObservableCollection<ShapeModel> ShapeList
        {
            get { return GetProperty(() => ShapeList); }
            set { SetProperty(() => ShapeList, value); }
        }
        #endregion

        #region 생성자
        public DrawViewModel(ArtistModel<double> artistModel)
        {
            ArtistModels = artistModel;
            _shape = new Box();
        }
        #endregion

        #region 메소드
        public void Update(ArtistModel<double> artistModel)
        {
            ArtistModels = artistModel;

            _createBoxData();
        }

        void _createBoxData()
        {
            ShapeList = _shape.CreateList(ArtistModels, Brushes.Black);
        }
        #endregion
    }
}
