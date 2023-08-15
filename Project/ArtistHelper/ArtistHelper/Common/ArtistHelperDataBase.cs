using ArtistHelper.Model;
using System.Collections.ObjectModel;

namespace ArtistHelper.Common
{
    static class ArtistHelperDataBase
    {
        public static string ViewPanelName { get; set; }
        public static ObservableCollection<PanelModel> PanelModels { get; set; }
    }
}
