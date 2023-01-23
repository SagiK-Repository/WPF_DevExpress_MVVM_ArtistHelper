namespace ArtistHelper.Model
{
    public class ArtistModel
    {
        #region 프로퍼티
        public int Width { get; set; } // 이미지 가로 사이즈
        public int Height { get; set; } // 이미지 세로 사이즈
        public int LineGrid { get; set; } // 선 굵기
        public int MinWidth { get; set; } // 사각형 최소 가로 길이
        public int MinHeight { get; set; } // 사각형 최소 세로 길이
        public int EndPointX { get; set; } // 종점 x
        public int EndPointY { get; set; } // 종점 y
        public int BoxCount { get; set; } // 사각형 개수
        public int FigureType { get; set; } // 도형 종류
        public string Name { get; set; }
        #endregion

        #region 생성자
        public ArtistModel(int width, int height, int lineGrid, int minWidth, int minHeight, int endPointX, int endPointY, int boxCount, int figureType)
        {
            Width = width;
            Height = height;
            LineGrid = lineGrid;
            MinWidth = minWidth;
            MinHeight = minHeight;
            EndPointX = endPointX;
            EndPointY = endPointY;
            BoxCount = boxCount;
            FigureType = figureType;
        }
        public ArtistModel(ArtistModel artists)
        {
            Width = artists.Width;
            Height = artists.Height;
            LineGrid = artists.LineGrid;
            MinWidth = artists.MinWidth;
            MinHeight = artists.MinHeight;
            EndPointX = artists.EndPointX;
            EndPointY = artists.EndPointY;
            BoxCount = artists.BoxCount;
            FigureType = artists.FigureType;
        }
        #endregion
    }
}
