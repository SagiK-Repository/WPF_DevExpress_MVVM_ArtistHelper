using FluentAssertions;
using System.IO;
using Xunit;

namespace Utility.LogService.Test
{

    public class Logger_Test
    {
        private readonly Logger _logger;
        private readonly string _logFilePath;

        public Logger_Test()
        {
            _logger = new Logger(NLog.LogManager.GetCurrentClassLogger());
            _logFilePath = "./log/Utility.LogAnalyzer.Test.log";
        }

        #region Log Test
        [Fact]
        public void DebugLog_Test()
        {
            // Clean Up
            DeleteFolders(".\\log");

            // Arrange
            string message = "Debug message";

            // Act
            _logger.Debug(message);

            // Assert
            File.Copy(_logFilePath, _logFilePath + "_"); // 프로세스 사용중에 의한 파일 복사 접근
            string logContent = File.ReadAllText(_logFilePath + "_", System.Text.Encoding.Unicode);
            logContent.Should().Contain("Logger_Test");
            logContent.Should().Contain("DEBUG");
            logContent.Should().Contain(message);

            // Clean Up
            DeleteFolders(".\\log");
        }

        [Fact]
        public void InfoLog_Test()
        {
            // Clean Up
            DeleteFolders(".\\log");

            // Arrange
            string message = "Info message";

            // Act
            _logger.Info(message);

            // Assert
            File.Copy(_logFilePath, _logFilePath + "_");
            string logContent = File.ReadAllText(_logFilePath + "_", System.Text.Encoding.Unicode);
            logContent.Should().Contain("Logger_Test");
            logContent.Should().Contain("INFO");
            logContent.Should().Contain(message);

            // Clean Up
            DeleteFolders(".\\log");
        }

        [Fact]
        public void WarnLog_Test()
        {
            // Clean Up
            DeleteFolders(".\\log");

            // Arrange
            string message = "Warning message";

            // Act
            _logger.Warn(message);

            // Assert
            File.Copy(_logFilePath, _logFilePath + "_");
            string logContent = File.ReadAllText(_logFilePath + "_", System.Text.Encoding.Unicode);
            logContent.Should().Contain("Logger_Test");
            logContent.Should().Contain("WARN");
            logContent.Should().Contain(message);

            // Clean Up
            DeleteFolders(".\\log");
        }

        [Fact]
        public void ErrorLog_Test()
        {
            // Clean Up
            DeleteFolders(".\\log");

            // Arrange
            string message = "Error message";

            // Act
            _logger.Error(message);

            // Assert
            File.Copy(_logFilePath, _logFilePath + "_");
            string logContent = File.ReadAllText(_logFilePath + "_", System.Text.Encoding.Unicode);
            logContent.Should().Contain("Logger_Test");
            logContent.Should().Contain("ERROR");
            logContent.Should().Contain(message);

            // Clean Up
            DeleteFolders(".\\log");
        }
        #endregion

        #region Log Action Test
        [Fact]
        public void DebugAction_Test()
        {
            // Clean Up
            DeleteFolders(".\\log");

            // Arrange
            string message = "DebugAction message";
            string actionMessage = "Action executed.";

            // Act
            _logger.DebugAction(message, () => { _logger.Debug(actionMessage); });

            // Assert
            File.Copy(_logFilePath, _logFilePath + "_");
            string logContent = File.ReadAllText(_logFilePath + "_", System.Text.Encoding.Unicode);
            logContent.Should().Contain("Logger_Test");
            logContent.Should().Contain("DEBUG");
            logContent.Should().Contain(message);
            logContent.Should().Contain(actionMessage);

            // Clean Up
            DeleteFolders(".\\log");
        }

        [Fact]
        public void TryCatchDebugAction_Test()
        {
            // Clean Up
            DeleteFolders(".\\log");

            // Arrange
            string message = "TryCatchDebugAction message";
            string actionMessage = "Action executed.";

            // Act
            _logger.TryCatchDebugAction(message, () => { throw new InvalidDataException("Exception Test"); });

            // Assert
            File.Copy(_logFilePath, _logFilePath + "_");
            string logContent = File.ReadAllText(_logFilePath + "_", System.Text.Encoding.Unicode);
            logContent.Should().Contain("Logger_Test");
            logContent.Should().Contain("DEBUG");
            logContent.Should().Contain(message);
            logContent.Should().NotContain(actionMessage);
            logContent.Should().Contain("Exception Test");
            logContent.Should().Contain("ERROR");

            // Clean Up
            DeleteFolders(".\\log");
        }

        [Fact]
        public void InfoAction_Test()
        {
            // Clean Up
            DeleteFolders(".\\log");

            // Arrange
            string message = "InfoAction message";
            string actionMessage = "Action executed.";

            // Act
            _logger.InfoAction(message, () => { _logger.Info(actionMessage); });

            // Assert
            File.Copy(_logFilePath, _logFilePath + "_");
            string logContent = File.ReadAllText(_logFilePath + "_", System.Text.Encoding.Unicode);
            logContent.Should().Contain("Logger_Test");
            logContent.Should().Contain("INFO");
            logContent.Should().Contain(message);
            logContent.Should().Contain(actionMessage);

            // Clean Up
            DeleteFolders(".\\log");
        }

        [Fact]
        public void TryCatchInfoAction_Test()
        {
            // Clean Up
            DeleteFolders(".\\log");

            // Arrange
            string message = "TryCatchInfoAction message";
            string actionMessage = "Action executed.";

            // Act
            _logger.TryCatchInfoAction(message, () => { throw new InvalidDataException("Exception Test"); });

            // Assert
            File.Copy(_logFilePath, _logFilePath + "_");
            string logContent = File.ReadAllText(_logFilePath + "_", System.Text.Encoding.Unicode);
            logContent.Should().Contain("Logger_Test");
            logContent.Should().Contain("INFO");
            logContent.Should().Contain(message);
            logContent.Should().NotContain(actionMessage);
            logContent.Should().Contain("Exception Test");
            logContent.Should().Contain("ERROR");

            // Clean Up
            DeleteFolders(".\\log");
        }
        #endregion

        #region Start End Log Test
        [Fact]
        public void StartEndLog_Test()
        {
            // Clean Up
            DeleteFolders(".\\log");

            // Arrange
            string actionName = "StartEndLog Action";
            string actionMessage = "Action executed.";

            // Act
            _logger.StartEndLog(actionName, () => { _logger.Info(actionMessage); });

            // Assert
            File.Copy(_logFilePath, _logFilePath + "_");
            string logContent = File.ReadAllText(_logFilePath + "_", System.Text.Encoding.Unicode);
            logContent.Should().Contain("Logger_Test");
            logContent.Should().Contain("INFO");
            logContent.Should().Contain(actionName + " Start");
            logContent.Should().Contain(actionMessage);
            logContent.Should().Contain(actionName + " End");

            // Clean Up
            DeleteFolders(".\\log");
        }

        [Fact]
        public void TryCatchStartEndLog_Test()
        {
            // Clean Up
            DeleteFolders(".\\log");

            // Arrange
            string actionName = "TryCatchStartEndLog Action";

            // Act
            _logger.TryCatchStartEndLog(actionName, () => { throw new InvalidDataException("Exception Test"); });

            // Assert
            File.Copy(_logFilePath, _logFilePath + "_");
            string logContent = File.ReadAllText(_logFilePath + "_", System.Text.Encoding.Unicode);
            logContent.Should().Contain("Logger_Test");
            logContent.Should().Contain(actionName + " Start");
            logContent.Should().Contain("Exception Test");
            logContent.Should().Contain(actionName + " End");

            // Clean Up
            DeleteFolders(".\\log");
        }
        #endregion

        #region LogSecond
        [Fact]
        public void LogSecond_Test()
        {
            // Clean Up
            DeleteFolders(".\\log");

            // Arrange
            string message = "LogSecond";

            // Act
            _logger.LogSecond(message, () =>
            {
                _logger.Error("Is Test");
            });

            // Assert
            File.Copy(_logFilePath, _logFilePath + "_");
            string logContent = File.ReadAllText(_logFilePath + "_", System.Text.Encoding.Unicode);
            logContent.Should().Contain("Logger_Test");
            logContent.Should().Contain("INFO");
            logContent.Should().Contain("DEBUG");
            logContent.Should().Contain("Start");
            logContent.Should().Contain("[Success]");
            logContent.Should().Contain("Elapsed Time");
            logContent.Should().Contain("ERROR");
            logContent.Should().Contain("Is Test");
            logContent.Should().Contain(message);

            // Clean Up
            DeleteFolders(".\\log");
        }

        [Fact]
        public void TryCatchLogSecond_Test()
        {
            // Clean Up
            DeleteFolders(".\\log");

            // Arrange
            string actionName = "TryCatchLogSecond Action";

            // Act
            _logger.TryCatchLogSecond(actionName, () => { _logger.Info("Action executed."); });

            // Assert
            File.Copy(_logFilePath, _logFilePath + "_");
            string logContent = File.ReadAllText(_logFilePath + "_", System.Text.Encoding.Unicode);
            logContent.Should().Contain("Logger_Test");
            logContent.Should().Contain("INFO");
            logContent.Should().Contain("DEBUG");
            logContent.Should().Contain(actionName);
            logContent.Should().Contain("Start");
            logContent.Should().Contain("[Success]");
            logContent.Should().Contain("Elapsed Time");

            // Clean Up
            DeleteFolders(".\\log");
        }
        #endregion

        #region Method

        private void DeleteFolders(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                foreach (string filePath in Directory.GetFiles(folderPath))
                    File.Delete(filePath);

                foreach (string dirPath in Directory.GetDirectories(folderPath))
                    DeleteFolders(dirPath);

                Directory.Delete(folderPath);
            }
        }
        #endregion
    }
}
