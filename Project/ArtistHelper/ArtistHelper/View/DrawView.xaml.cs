using ArtistHelper.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ArtistHelper.View
{
    public partial class DrawView : UserControl
    {
        public DrawView(DrawViewModel drawViewModel)
        {
            InitializeComponent();
            DataContext = drawViewModel;
        }

        public Canvas GetCurrentCanvas()
        {
            return _findDrawCanvas(this);
        }

        private Canvas _findDrawCanvas(DependencyObject parent)
        {
            if (parent == null)
            {
                return null;
            }

            int childCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);

                if (child is Canvas canvas && canvas.Name == "DrawCanvas")
                {
                    return canvas;
                }

                Canvas foundCanvas = _findDrawCanvas(child);
                if (foundCanvas != null)
                {
                    return foundCanvas;
                }
            }

            return null;
        }
    }
}
