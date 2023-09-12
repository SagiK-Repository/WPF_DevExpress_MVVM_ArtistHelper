using System;
using System.Diagnostics;
using System.Windows;

namespace Utility.LogService
{
    /// <summary>
    /// Log를 기록하는 Class
    /// </summary>
    public class Logger
    {
        private NLog.Logger _logger;
        public string ResultMessage = "Success";

        public Logger(NLog.Logger logger)
        {
            _logger = logger;
        }

        #region Log
        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }
        #endregion

        #region Action Log
        public void DebugAction(string message, Action action)
        {
            _logger.Debug(message);
            action();
        }
        public void TryCatchDebugAction(string message, Action action)
        {
            DebugAction(message, () => TryCatchAction(message, action));
        }

        public void InfoAction(string message, Action action)
        {
            _logger.Info(message);
            action();
        }
        public void TryCatchInfoAction(string message, Action action)
        {
            InfoAction(message, () => TryCatchAction(message, action));
        }
        #endregion

        #region Start End Log
        /// <summary>
        /// 실행 Action 앞 뒤로 Start, End 로그를 개록
        /// </summary>
        /// <param name="actionName">action에 대한 이름</param>
        /// <param name="action"></param>
        public void StartEndLog(string actionName, Action action)
        {
            _logger.Info(actionName + " Start");
            action();
            _logger.Info(actionName + " End");
        }

        public void TryCatchStartEndLog(string actionName, Action action)
        {
            StartEndLog(actionName, () => TryCatchAction(actionName, action));
        }
        #endregion

        #region LogSecond
        /// <summary>
        /// 실행 Action에 대한 소요 시간 로그를 기록
        /// </summary>
        /// <param name="actionName">action에 대한 이름</param>
        /// <param name="action"></param>
        public void LogSecond(string actionName, Action action)
        {
            _logger.Info(actionName + " Start");

            Stopwatch stopwatch = Stopwatch.StartNew();

            action();

            stopwatch.Stop();

            _logger.Info($"[{ResultMessage}] " + actionName);
            _logger.Debug(actionName + " Elapsed Time: {0}s", stopwatch.Elapsed.TotalSeconds);
        }

        /// <summary>
        /// 실행 Action에 대한 예외 및 소요 시간 로그를 기록
        /// </summary>
        /// <param name="actionName">action에 대한 이름</param>
        /// <param name="action"></param>
        public void TryCatchLogSecond(string actionName, Action action)
        {
            ResultMessage = "Success";

            LogSecond(actionName, () =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    ResultMessage = "Failed";
                    _logger.Error($"Exception In {actionName}, ex = {ex.Message}");
                }
            });
        }
        #endregion

        #region MessegeBox Log
        public MessageBoxResult MessageBoxLog(string messageBox, string title, MessageBoxButton button, MessageBoxImage icon)
        {
            _logger.Info($"MessageBox Show {title} {messageBox}");
            return MessageBox.Show(messageBox, title, button, icon);
        }
        #endregion

        private void TryCatchAction(string message, Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception In {message}, ex = {ex.Message}");
            }
        }
    }
}
