using ArtistHelper.ViewModel;
using System.Windows.Controls;

namespace ArtistHelper.View
{
    public partial class PanelView : UserControl
    {
        public PanelView(PanelViewModel panelViewModel)
        {
            InitializeComponent();
            DataContext= panelViewModel;
        }
    }
}
