using CleanApi.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace CleanApi.Application.Common.Behaviours;

public class LoggingBehaviour<TMessage, TResponse>(
    ILogger<TMessage> logger,
    IUser user,
    IIdentityService identityService)
    : IPipelineBehavior<TMessage, TResponse> where TMessage : IMessage
{
    private readonly ILogger _logger = logger;
    private readonly IUser _user = user;
    private readonly IIdentityService _identityService = identityService;

    public async ValueTask<TResponse> Handle(TMessage message, MessageHandlerDelegate<TMessage, TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TMessage).Name;
        var userId = _user.Id ?? string.Empty;
        string? userName = string.Empty;

        if (!string.IsNullOrEmpty(userId))
        {
            userName = await _identityService.GetUserNameAsync(userId);
        }

        _logger.LogInformation("CleanApi Request: {Name} {@UserId} {@UserName} {@Request}",
            requestName, userId, userName, message);

        return await next(message, cancellationToken);
    }
}
