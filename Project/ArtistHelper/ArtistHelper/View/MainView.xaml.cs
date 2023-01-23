using ArtistHelper.ViewModel;
using System.Windows;

namespace ArtistHelper.View
{
    public partial class MainView : Window, IWindowView
    {
        public MainView(MainViewModel mainViewModel)
        {
            InitializeComponent();
            DataContext = mainViewModel;
        }
    }
}
