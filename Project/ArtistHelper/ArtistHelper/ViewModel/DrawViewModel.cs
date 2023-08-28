using ArtistHelper.Model;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows.Media;

namespace ArtistHelper.ViewModel
{
    public class DrawViewModel
    {
        #region 변수
        #endregion

        #region 프로퍼티
        public ArtistModel<double> ArtistModels { get; set; }
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
        #region Box Method
        #endregion

        #region 생성자
        public DrawViewModel(ArtistModel<double> artistModel)
        {
            ArtistModels = artistModel;
        }
        #endregion

        #region 메소드
        public void Update()
        public void Update(ArtistModel<double> artistModel)
        {
            ArtistModels = artistModel;

        }
        }
        #endregion
    }
}
