using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Docking;
using System;
using System.Linq;

namespace ArtistHelper.Common.Service
{
    /// <summary>
    /// Docking Panel 관련 이벤트 수동 제어를 위한 Service
    /// </summary>
    public class DockLayoutManagerEventsService : ServiceBase
    {
        #region Variable
        private string _previousDockName = "";
        #endregion

        public DockLayoutManager DockLayoutManager => AssociatedObject as DockLayoutManager;

        public DockLayoutManagerEventsService()
        {
            Messenger.Default.Register<string>(this, OnMessage);
        }

        private void OnMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;

            var splitMessage = message.Split(new[] {" : "}, StringSplitOptions.RemoveEmptyEntries);

            if (splitMessage[2] == "Docking Activating")
            {
                ActivatePanel(splitMessage[3]);
            }
        }

        #region Event
        protected override void OnAttached()
        {
            base.OnAttached();
            DockLayoutManager.DockItemActivated += DockLayoutManager_DockItemActivated;
            DockLayoutManager.DockOperationCompleted += DockLayoutManager_DockOperationCompleted;
            DockLayoutManager.DockItemActivating += DockLayoutManager_DockItemActivating;
        }
        protected override void OnDetaching()
        {
            DockLayoutManager.DockItemActivated -= DockLayoutManager_DockItemActivated;
            DockLayoutManager.DockOperationCompleted -= DockLayoutManager_DockOperationCompleted;
            DockLayoutManager.DockItemActivating -= DockLayoutManager_DockItemActivating;
            base.OnDetaching();
        }
        #endregion

        #region Event Method
        private void DockLayoutManager_DockOperationCompleted(object sender, DevExpress.Xpf.Docking.Base.DockOperationCompletedEventArgs e)
        {
            if (e.DockOperation.ToString() == "Close")
            {
                var message = $"DockLayoutManagerEventsService -> MainViewModel : Docking Closed : {e.Item.CustomizationCaption}";
                Messenger.Default.Send(message);
                NLog.LogManager.GetCurrentClassLogger().Debug("Messenger.Default.Send : " + message);
            }
        }

        private void DockLayoutManager_DockItemActivating(object sender, DevExpress.Xpf.Docking.Base.ItemCancelEventArgs e)
        {
            if (e.Item == null ||
                e.Item.CustomizationCaption == "DocumentPanel" ||
                e.Item.CustomizationCaption == "documentGroup" ||
                e.Item.CustomizationCaption == "DocumentGroup" ||
                e.Item.CustomizationCaption == "root")
                return;

            _previousDockName = e.Item.CustomizationCaption;

            var message = $"DockLayoutManagerEventsService -> MainViewModel : Docking Item Activating : {e.Item.CustomizationCaption}";
            Messenger.Default.Send(message);
            NLog.LogManager.GetCurrentClassLogger().Debug("Messenger.Default.Send : " + message);
        }

        private void DockLayoutManager_DockItemActivated(object sender, DevExpress.Xpf.Docking.Base.DockItemActivatedEventArgs e)
        {
            if (e.Item == null ||
                e.Item.CustomizationCaption == "DocumentPanel" ||
                e.Item.CustomizationCaption == "documentGroup" ||
                e.Item.CustomizationCaption == "DocumentGroup" ||
                e.Item.CustomizationCaption == "root")
                return;

            if (_previousDockName != e.Item.CustomizationCaption)
            {
                var message = $"DockLayoutManagerEventsService -> MainViewModel : Docking Item Activated : {e.Item.CustomizationCaption}";
                Messenger.Default.Send(message);
                NLog.LogManager.GetCurrentClassLogger().Debug("Messenger.Default.Send : " + message);
            }
        }
        #endregion

        private void ActivatePanel(string panelName)
        {
            var panel = DockLayoutManager.GetItems().Where(x => x is DocumentPanel && x.Caption.ToString() == panelName).FirstOrDefault();
            if (panel != null)
                DockLayoutManager.Activate(panel);
        }
    }
}
