using ArtistHelper.Model;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.LogService;

namespace ArtistHelper.Common.Service
{
    public static class NewPanelService
    {
        private static Logger _logger = new Logger(NLog.LogManager.GetCurrentClassLogger());

        public static (PanelModel, string) GetNewPanel()
        {
            (PanelModel, string) returnData = (new PanelModel(), "");

            _logger.StartEndLog("Get New Panel", () => returnData = _getNewPanel());

            return returnData;
        }

        public static string GetName()
        {
            string newName = "";

            _logger.TryCatchStartEndLog("Get New Name", () => newName = _getName());
            _logger.Info($"Get New Name, {newName}");

            return newName;
        }

        #region private Method
        private static (PanelModel, string) _getNewPanel()
        {
            string panelName = GetName();
            var newPanel = new PanelModel() { Caption = panelName, TargetName = "documentGroup" };
            return (newPanel, panelName);
        }

        private static string _getName()
        {
            var panelModel = ArtistHelperDataBase.PanelModels.FirstOrDefault(x => x.Caption == "NewDraw");
            if (panelModel == null)
                return "NewDraw";

            return _getNumberName();
        }

        private static string _getNumberName()
        {
            int num = 1;
            while (true)
            {
                var panelModel = ArtistHelperDataBase.PanelModels.FirstOrDefault(x => x.Caption == $"NewDraw {num}");
                if (panelModel == null)
                    return $"NewDraw {num}";
                num++;
            }
        } 
        #endregion
    }
}
