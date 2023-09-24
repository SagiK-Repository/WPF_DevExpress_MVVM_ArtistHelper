using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Utility.LogService;

namespace ArtistHelper.Common.Service
{
    public class CanvasImageService
    {
        Logger _logger;

        public CanvasImageService() => _logger = new Logger(NLog.LogManager.GetCurrentClassLogger());

        public void SaveCanvasAsImage(Canvas canvas, string path)
        {
            if (canvas == null || string.IsNullOrEmpty(path))
            {
                _logger.Error("Input Data Is Null");
                MessageBox.Show("Image Is Null", "Image Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                _logger.StartEndLog("Save Canvas As Image", () => _saveCanvasAsImage(canvas, path));
        }

        private void _saveCanvasAsImage(Canvas canvas, string filePath)
        {
            _rendererCanvas(canvas);

            PngBitmapEncoder encoder = _convertCanvasToPngBitmapEncoder(canvas);

            _savePngBitmapEncoder(filePath, encoder);
        }

        #region 보조 코드
        private static PngBitmapEncoder _convertCanvasToPngBitmapEncoder(Canvas canvas)
        {
            var renderBitmap =
                new RenderTargetBitmap(
                    (int)canvas.ActualWidth,
                    (int)canvas.ActualHeight,
                    96d,
                    96d,
                    PixelFormats.Pbgra32);

            renderBitmap.Render(canvas);

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
            return encoder;
        }

        private static void _rendererCanvas(Canvas canvas)
        {
            canvas.Measure(new Size(canvas.ActualWidth, canvas.ActualHeight));
            canvas.Arrange(new Rect(new Size(canvas.ActualWidth, canvas.ActualHeight)));
            canvas.UpdateLayout();
        }

        private static void _savePngBitmapEncoder(string filePath, PngBitmapEncoder encoder)
        {
            using (var fileStream =
                   new System.IO.FileStream(filePath, System.IO.FileMode.Create))
            {
                encoder.Save(fileStream);
                fileStream.Close();
            }
        } 
        #endregion
    }
}
