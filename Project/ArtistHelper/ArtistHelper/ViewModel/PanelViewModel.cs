using ArtistHelper.Model;
using DevExpress.Mvvm;
using System;

namespace ArtistHelper.ViewModel
{
    public class PanelViewModel : ViewModelBase
    {
        #region 변수
        #endregion

        #region 프로퍼티
        public ArtistModel<double> ArtistModels
        {
            get { return GetProperty(() => ArtistModels); }
            set { SetProperty(() => ArtistModels, value); }
        }
        public double Width
        {
            get => ArtistModels.Width.GetValue();
            set => ArtistModels.Width.ModifyValue(value);
        }
        public double Height
        {
            get => ArtistModels.Height.GetValue();
            set => ArtistModels.Height.ModifyValue(value);
        }
        public double LineGrid
        {
            get => ArtistModels.LineGrid.GetValue();
            set => ArtistModels.LineGrid.ModifyValue(value);
        }
        public double MinWidth
        {
            get => ArtistModels.MinWidth.GetValue();
            set => ArtistModels.MinWidth.ModifyValue(value);
        }
        public double MinHeight
        {
            get => ArtistModels.MinHeight.GetValue();
            set => ArtistModels.MinHeight.ModifyValue(value);
        }
        public double EndPointX
        {
            get => ArtistModels.EndPoint.X.GetValue();
            set => ArtistModels.EndPoint.X.ModifyValue(value);
        }
        public double EndPointY
        {
            get => ArtistModels.EndPoint.Y.GetValue();
            set => ArtistModels.EndPoint.Y.ModifyValue(value);
        }
        public int BoxCount
        {
            get => Convert.ToInt32(ArtistModels.BoxCount.GetValue());
            set => ArtistModels.BoxCount.ModifyValue(Convert.ToDouble(value));
        }
        #endregion

        #region 생성자
        public PanelViewModel()
        {
            Initialize();
        }
        private void Initialize()
        {
            ArtistModels = new ArtistModel<double>()
            {
                Width = new Width<double>(10, 0, 1000),
                Height = new Height<double>(100, 0, 1000),
                LineGrid = new Grid<double>(10),
                MinWidth = new Width<double>(0, 0, 1000),
                MinHeight = new Height<double>(0, 0, 1000),
                EndPoint = new Point<double>(0, 0),
                BoxCount = new Count<double>(1, 0, 10)
            };
        }
        #endregion

        #region 메소드
        #endregion
    }
}
