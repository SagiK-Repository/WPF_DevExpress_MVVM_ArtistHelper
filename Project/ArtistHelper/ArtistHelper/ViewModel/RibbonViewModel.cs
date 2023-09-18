using DevExpress.Mvvm;
using System.Windows;
using System.Windows.Input;

namespace ArtistHelper.ViewModel
{
    public class RibbonViewModel
    {
        #region 커멘드
        public ICommand NewCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        #endregion

        #region 생성자
        public RibbonViewModel()
        {
            SaveCommand = new DelegateCommand(_saveCommandAction);
            NewCommand = new DelegateCommand(_newCommandAction);
        }
        #endregion

        #region 메소드
        private void _saveCommandAction()
        {
            MessageBox.Show("SavePanel");
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
