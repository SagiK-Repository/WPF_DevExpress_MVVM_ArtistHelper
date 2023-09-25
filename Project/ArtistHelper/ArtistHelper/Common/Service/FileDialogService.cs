using Microsoft.Win32;
using Utility.LogService;

namespace ArtistHelper.Common.Service
{
    public class FileDialogService
    {
        Logger _logger;

        public FileDialogService() => _logger = new Logger(NLog.LogManager.GetCurrentClassLogger());
        public string GetSaveFilePath(string defaultFileName)
        {
            string returnString = "";
            _logger.StartEndLog("Get SaveFilePath From SaveFileDialog", () => returnString = _getSaveFilePath(defaultFileName));
            return returnString;
        }

        private string _getSaveFilePath(string defaultFileName)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = defaultFileName; // 기본 파일명 설정

            if (saveFileDialog.ShowDialog() == true)
                return saveFileDialog.FileName;

            return "";
        }
    }
}
