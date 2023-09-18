using ArtistHelper.Model;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace ArtistHelper.Interface
{
    public interface IShape
    {
        ObservableCollection<ShapeModel> CreateList(ArtistModel<double> artistModel, SolidColorBrush colorBrush);
    }
}
