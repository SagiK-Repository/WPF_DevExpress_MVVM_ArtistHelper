using ArtistHelper.Interface;
using ArtistHelper.Model;
using ArtistHelper.Common.ShapeList;
using DevExpress.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace ArtistHelper.ViewModel
{
    public class DrawViewModel : ViewModelBase
    {
        IShape _shape;

        #region 프로퍼티
        public ArtistModel<double> ArtistModels { get; set; }
        public double Width
        {
            get => ArtistModels.Width.GetValue();
        }
        public double Height
        {
            get => ArtistModels.Height.GetValue();
        }
        public double LineGrid
        {
            get => ArtistModels.LineGrid.GetValue();
        }
        public double MinWidth
        {
            get => ArtistModels.MinWidth.GetValue();
        }
        public double MinHeight
        {
            get => ArtistModels.MinHeight.GetValue();
        }
        public double EndPointX
        {
            get => ArtistModels.EndPoint.X.GetValue();
        }
        public double EndPointY
        {
            get => ArtistModels.EndPoint.Y.GetValue();
        }
        public int BoxCount
        {
            get => Convert.ToInt32(ArtistModels.BoxCount.GetValue());
        }
        public ObservableCollection<ShapeModel> ShapeList
        {
            get { return GetProperty(() => ShapeList); }
            set { SetProperty(() => ShapeList, value); }
        }
        #endregion

        #region Box Method
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
