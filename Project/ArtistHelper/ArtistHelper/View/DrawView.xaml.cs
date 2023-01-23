using ArtistHelper.ViewModel;
using System.Windows.Controls;

namespace ArtistHelper.View
{
    public partial class DrawView : UserControl
    {
        public DrawView(DrawViewModel drawViewModel)
        {
            InitializeComponent();
            DataContext = drawViewModel;
        }
    }
}
