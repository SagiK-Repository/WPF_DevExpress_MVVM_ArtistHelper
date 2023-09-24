using ArtistHelper.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArtistHelper.Common
{
    static class ArtistHelperDataBase
    {
        public static string ViewPanelName { get; set; }
        public static ObservableCollection<PanelModel> PanelModels { get; set; }

        public static PanelModel GetPenel()
        {
            return PanelModels.Where(x => x.Caption == ViewPanelName).FirstOrDefault();
        }

        public static ArtistModel<double> GetDefaultArtistModel() => new ArtistModel<double>()
            {
                Width = new Width<double>(1000, 0, 1000),
                Height = new Height<double>(1000, 0, 1000),
                LineGrid = new Grid<double>(1),
                MinWidth = new Width<double>(10, 0, 1000),
                MinHeight = new Height<double>(10, 0, 1000),
                EndPoint = new Point<double>(150, 150),
                BoxCount = new Count<double>(10, 0, 1000)
            };
}
}
