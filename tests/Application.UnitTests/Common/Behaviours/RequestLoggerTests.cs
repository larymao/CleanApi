using CleanApi.Application.Common.Behaviours;
using CleanApi.Application.Common.Interfaces;
using CleanApi.Application.TodoItems.Commands.CreateTodoItem;
using Mediator;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace CleanApi.Application.UnitTests.Common.Behaviours;

public class RequestLoggerTests
{
    private Mock<ILogger<CreateTodoItemCommand>> _logger = null!;
    private Mock<IUser> _user = null!;
    private Mock<IIdentityService> _identityService = null!;

    [SetUp]
    public void Setup()
    {
        _logger = new Mock<ILogger<CreateTodoItemCommand>>();
        _user = new Mock<IUser>();
        _identityService = new Mock<IIdentityService>();
    }

    [Test]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        _user.Setup(x => x.Id).Returns(Guid.NewGuid().ToString());

        var requestLogger = new LoggingBehaviour<CreateTodoItemCommand, string>(_logger.Object, _user.Object, _identityService.Object);

        var command = new CreateTodoItemCommand { ListId = Guid.NewGuid().ToString(), Title = "title" };
        var next = new MessageHandlerDelegate<CreateTodoItemCommand, string>((cmd, ct) => ValueTask.FromResult("ffffffff-ffff-ffff-ffff-ffffffffffff"));

        await requestLogger.Handle(command, next, CancellationToken.None);

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
    {
        var requestLogger = new LoggingBehaviour<CreateTodoItemCommand, string>(_logger.Object, _user.Object, _identityService.Object);

        var command = new CreateTodoItemCommand { ListId = Guid.NewGuid().ToString(), Title = "title" };
        var next = new MessageHandlerDelegate<CreateTodoItemCommand, string>((cmd, ct) => ValueTask.FromResult("ffffffff-ffff-ffff-ffff-ffffffffffff"));

        await requestLogger.Handle(command, next, CancellationToken.None);

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Never);
    }
}
