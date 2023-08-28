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
    }
}
