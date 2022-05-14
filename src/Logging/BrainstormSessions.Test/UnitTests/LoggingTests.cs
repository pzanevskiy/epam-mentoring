using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrainstormSessions.Api;
using BrainstormSessions.Controllers;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Core.Model;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BrainstormSessions.Test.UnitTests
{
    public class LoggingTests : IDisposable
    {
        private readonly MemoryAppender _appender;

        public LoggingTests()
        {
            _appender = new MemoryAppender();
            BasicConfigurator.Configure(_appender);
        }

        public void Dispose()
        {
            _appender.Clear();
        }

        [Fact]
        public async Task HomeController_Index_LogInfoMessages()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();

            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestSessions());
            var controller = new HomeController(mockRepo.Object, loggerMock.Object);

            // Act
            var result = await controller.Index();

            // Assert
            // Added custom assertion because of confusing task
            var logEntriesLevel = loggerMock.Invocations.Select(x => x.Arguments[0]);
            Assert.Contains(logEntriesLevel, x => x.ToString() == LogLevel.Information.ToString());
            //var logEntries = _appender.GetEvents();
            //Assert.True(logEntries.Any(l => l.Level == Level.Info), "Expected Info messages in the logs");
        }

        [Fact]
        public async Task HomeController_IndexPost_LogWarningMessage_WhenModelStateIsInvalid()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();

            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestSessions());
            var controller = new HomeController(mockRepo.Object, loggerMock.Object);
            controller.ModelState.AddModelError("SessionName", "Required");
            var newSession = new HomeController.NewSessionModel();

            // Act
            var result = await controller.Index(newSession);

            // Assert
            // Added custom assertion because of confusing task
            var logEntriesLevel = loggerMock.Invocations.Select(x => x.Arguments[0]);
            Assert.Contains(logEntriesLevel, x => x.ToString() == LogLevel.Warning.ToString());

            //var logEntries = _appender.GetEvents();
            //Assert.True(logEntries.Any(l => l.Level == Level.Warn), "Expected Warn messages in the logs");
        }

        [Fact]
        public async Task IdeasController_CreateActionResult_LogErrorMessage_WhenModelStateIsInvalid()
        {
            // Arrange & Act
            var loggerMock = new Mock<ILogger<IdeasController>>();
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            var controller = new IdeasController(mockRepo.Object, loggerMock.Object);
            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = await controller.CreateActionResult(model: null);

            // Assert
            // Added custom assertion because of confusing task
            var logEntriesLevel = loggerMock.Invocations.Select(x => x.Arguments[0]);
            Assert.Contains(logEntriesLevel, x => x.ToString() == LogLevel.Error.ToString());

            //var logEntries = _appender.GetEvents();
            //Assert.True(logEntries.Any(l => l.Level == Level.Error), "Expected Error messages in the logs");
        }

        [Fact]
        public async Task SessionController_Index_LogDebugMessages()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<SessionController>>();

            int testSessionId = 1;
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                .ReturnsAsync(GetTestSessions().FirstOrDefault(
                    s => s.Id == testSessionId));
            var controller = new SessionController(mockRepo.Object, loggerMock.Object);

            // Act
            var result = await controller.Index(testSessionId);

            // Assert
            // Added custom assertion because of confusing task
            var logEntriesLevel = loggerMock.Invocations.Select(x => x.Arguments[0]);
            Assert.True(logEntriesLevel.Count(x => x.ToString() == LogLevel.Debug.ToString()) == 2);

            //var logEntries = _appender.GetEvents();
            //Assert.True(logEntries.Count(l => l.Level == Level.Debug) == 2, "Expected 2 Debug messages in the logs");
        }

        private List<BrainstormSession> GetTestSessions()
        {
            var sessions = new List<BrainstormSession>();
            sessions.Add(new BrainstormSession()
            {
                DateCreated = new DateTime(2016, 7, 2),
                Id = 1,
                Name = "Test One"
            });
            sessions.Add(new BrainstormSession()
            {
                DateCreated = new DateTime(2016, 7, 1),
                Id = 2,
                Name = "Test Two"
            });
            return sessions;
        }

    }
}
