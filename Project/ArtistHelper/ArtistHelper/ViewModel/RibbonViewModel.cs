using ArtistHelper.Common;
using ArtistHelper.Common.Service;
using DevExpress.Mvvm;
using System.Windows;
using System.Windows.Input;
using Utility.LogService;

namespace ArtistHelper.ViewModel
{
    public class RibbonViewModel
    {
        private Logger _logger;

        #region 커멘드
        public ICommand NewCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        #endregion

        #region 생성자
        public RibbonViewModel()
        {
            _logger = new Logger(NLog.LogManager.GetCurrentClassLogger());

            _logger.LogSecond("Initiallize", () => _initiallize());
        }

        private void _initiallize()
        {
            SaveCommand = new DelegateCommand(_saveCommandAction);
            NewCommand = new DelegateCommand(_newCommandAction);
        }
        #endregion

        #region 메소드
        private void _saveCommandAction()
        {
            _logger.InfoAction("Start Save Command", () =>
            {
                MessageBox.Show("SavePanel");
            });
        }

        private void _newCommandAction()
        {
            _logger.InfoAction("Start New Command", () =>
            {
                var newPanel = NewPanelService.GetNewPanel().Item1;
                ArtistHelperDataBase.PanelModels.Add(newPanel);
            });
        }
        #endregion
    }
}
