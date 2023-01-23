using System.Windows.Controls;
using ArtistHelper.ViewModel;

namespace ArtistHelper.View
{
    public partial class RibbonView : UserControl
    {
        public RibbonView(RibbonViewModel ribbonViewModel)
        {
            InitializeComponent();
            DataContext = ribbonViewModel;
        }
    }
}
