using ArtistHelper.Model;
using DevExpress.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows.Media;

namespace ArtistHelper.ViewModel
{
    public class DrawViewModel : ViewModelBase
    {
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
        }
        #endregion

        #region 메소드
        public void Update(ArtistModel<double> artistModel)
        {
            ArtistModels = artistModel;

            CreateBoxData();
        }

        public void CreateBoxData()
        {
            ShapeList = new ObservableCollection<ShapeModel>();

            double widthStep = (Width - MinWidth) / (BoxCount - 1);
            double heightStep = (Height - MinHeight) / (BoxCount - 1);
            double xStep = (EndPointX - Width / 2) / (BoxCount - 1);
            double yStep = (EndPointY - Height / 2) / (BoxCount - 1);

            for (int i = 0; i < BoxCount; i++)
            {
                double boxWidth = Width - (i * widthStep);
                double boxHeight = Height - (i * heightStep);
                double xPos = (i * xStep) + (Width / 2);
                double yPos = (i * yStep) + (Height / 2);

                ShapeList.Add(new ShapeModel
                {
                    Width = boxWidth,
                    Height = boxHeight,
                    StrokeThickness = LineGrid,
                    Stroke = Brushes.Black,
                    X = xPos,
                    Y = yPos
                });
            }
        }
        #endregion
    }
}
