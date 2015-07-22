using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Belatrix.Logger.Test
{
    [TestClass]
    public class AppCanLogToConsole
    {
        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            JobLogger.Instance.Setup(logToConsole: true);
        }

        [TestMethod]
        public void EnableAll()
        {
            try
            {
                JobLogger.Instance.Setup(logMessage: true, logWarning: true, logError: true);

                var messageLogged = JobLogger.Instance.LogMessage("Some message", MessageType.Message);
                var warningLogged = JobLogger.Instance.LogMessage("Some warning", MessageType.Warning);
                var errorLogged = JobLogger.Instance.LogMessage("Some error", MessageType.Error);

                Assert.IsTrue(messageLogged);
                Assert.IsTrue(warningLogged);
                Assert.IsTrue(errorLogged);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void MessageAndWarningEnabled()
        {
            try
            {
                JobLogger.Instance.Setup(logMessage: true, logWarning: true, logError: false);

                var messageLogged = JobLogger.Instance.LogMessage("Some message", MessageType.Message);
                var warningLogged = JobLogger.Instance.LogMessage("Some warning", MessageType.Warning);
                var errorLogged = JobLogger.Instance.LogMessage("Some error", MessageType.Error);

                Assert.IsTrue(messageLogged);
                Assert.IsTrue(warningLogged);
                Assert.IsFalse(errorLogged);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void MessageAndErrorEnabled()
        {
            try
            {
                JobLogger.Instance.Setup(logMessage: true, logWarning: false, logError: true);

                var messageLogged = JobLogger.Instance.LogMessage("Some message", MessageType.Message);
                var warningLogged = JobLogger.Instance.LogMessage("Some warning", MessageType.Warning);
                var errorLogged = JobLogger.Instance.LogMessage("Some error", MessageType.Error);

                Assert.IsTrue(messageLogged);
                Assert.IsFalse(warningLogged);
                Assert.IsTrue(errorLogged);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void WarningAndErrorEnabled()
        {
            try
            {
                JobLogger.Instance.Setup(logMessage: false, logWarning: true, logError: true);

                var messageLogged = JobLogger.Instance.LogMessage("Some message", MessageType.Message);
                var warningLogged = JobLogger.Instance.LogMessage("Some warning", MessageType.Warning);
                var errorLogged = JobLogger.Instance.LogMessage("Some error", MessageType.Error);

                Assert.IsFalse(messageLogged);
                Assert.IsTrue(warningLogged);
                Assert.IsTrue(errorLogged);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void OnlyMessageEnabled()
        {
            try
            {
                JobLogger.Instance.Setup(logMessage: true, logWarning: false, logError: false);

                var messageLogged = JobLogger.Instance.LogMessage("Some message", MessageType.Message);
                var warningLogged = JobLogger.Instance.LogMessage("Some warning", MessageType.Warning);
                var errorLogged = JobLogger.Instance.LogMessage("Some error", MessageType.Error);

                Assert.IsTrue(messageLogged);
                Assert.IsFalse(warningLogged);
                Assert.IsFalse(errorLogged);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void OnlyWarningEnabled()
        {
            try
            {
                JobLogger.Instance.Setup(logMessage: false, logWarning: true, logError: false);

                var messageLogged = JobLogger.Instance.LogMessage("Some message", MessageType.Message);
                var warningLogged = JobLogger.Instance.LogMessage("Some warning", MessageType.Warning);
                var errorLogged = JobLogger.Instance.LogMessage("Some error", MessageType.Error);

                Assert.IsFalse(messageLogged);
                Assert.IsTrue(warningLogged);
                Assert.IsFalse(errorLogged);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void OnlyErrorEnabled()
        {
            try
            {
                JobLogger.Instance.Setup(logMessage: false, logWarning: false, logError: true);

                var messageLogged = JobLogger.Instance.LogMessage("Some message", MessageType.Message);
                var warningLogged = JobLogger.Instance.LogMessage("Some warning", MessageType.Warning);
                var errorLogged = JobLogger.Instance.LogMessage("Some error", MessageType.Error);

                Assert.IsFalse(messageLogged);
                Assert.IsFalse(warningLogged);
                Assert.IsTrue(errorLogged);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void DisableAll()
        {
            try
            {
                JobLogger.Instance.Setup(logMessage: false, logWarning: false, logError: false);

                var messageLogged = JobLogger.Instance.LogMessage("Some message", MessageType.Message);
                var warningLogged = JobLogger.Instance.LogMessage("Some warning", MessageType.Warning);
                var errorLogged = JobLogger.Instance.LogMessage("Some error", MessageType.Error);

                Assert.IsFalse(messageLogged);
                Assert.IsFalse(warningLogged);
                Assert.IsFalse(errorLogged);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
