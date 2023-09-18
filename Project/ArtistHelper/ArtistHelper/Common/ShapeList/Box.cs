using ArtistHelper.Interface;
using ArtistHelper.Model;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows.Media;

namespace ArtistHelper.Common.ShapeList
{
    public class Box : IShape
    {
        private ArtistModel<double> _artistModel;

        private double _width { get => _artistModel.Width.GetValue(); }
        private double _height { get => _artistModel.Height.GetValue(); }
        private double _minWidth { get => _artistModel.MinWidth.GetValue(); }
        private double _minHeight { get => _artistModel.MinHeight.GetValue(); }
        private double _lineGrid { get => _artistModel.LineGrid.GetValue(); }
        private double _endPointX { get => _artistModel.EndPoint.X.GetValue(); }
        private double _endPointY { get => _artistModel.EndPoint.Y.GetValue(); }
        private int _boxCount { get => Convert.ToInt32(_artistModel.BoxCount.GetValue()); }

        public ObservableCollection<ShapeModel> CreateList(ArtistModel<double> artistModel, SolidColorBrush colorBrush)
        {
            var shapeList = new ObservableCollection<ShapeModel>();
            _artistModel = artistModel;

            double widthStep = (_width - _minWidth) / (_boxCount - 1);
            double heightStep = (_height - _minHeight) / (_boxCount - 1);
            double xStep = _endPointX / (_boxCount - 1);
            double yStep = _endPointY / (_boxCount - 1);
            double minWidthStep = (_minWidth / 2) / (_boxCount - 1);
            double minHeightStep = (_minHeight / 2) / (_boxCount - 1);

            for (int i = 0; i < _boxCount; i++)
            {
                double boxWidth = _width - (i * widthStep);
                double boxHeight = _height - (i * heightStep);
                double xPos = (i * xStep) - (i * minWidthStep);
                double yPos = (i * yStep) - (i * minHeightStep);

                shapeList.Add(new ShapeModel
                {
                    Width = boxWidth,
                    Height = boxHeight,
                    StrokeThickness = _lineGrid,
                    Stroke = colorBrush,
                    X = xPos,
                    Y = yPos
                });
            }

            return shapeList;
        }
    }
}
