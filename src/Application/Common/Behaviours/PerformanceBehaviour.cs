using System.Diagnostics;
using CleanApi.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace CleanApi.Application.Common.Behaviours;

public class PerformanceBehaviour<TMessage, TResponse>(
    ILogger<TMessage> logger,
    IUser user,
    IIdentityService identityService)
    : IPipelineBehavior<TMessage, TResponse> where TMessage : IMessage
{
    private readonly ILogger<TMessage> _logger = logger;
    private readonly IUser _user = user;
    private readonly IIdentityService _identityService = identityService;

    public async ValueTask<TResponse> Handle(TMessage message, CancellationToken cancellationToken, MessageHandlerDelegate<TMessage, TResponse> next)
    {
        var timer = Stopwatch.StartNew();

        var response = await next(message, cancellationToken);

        timer.Stop();

        var elapsedMilliseconds = timer.ElapsedMilliseconds;

        if (elapsedMilliseconds > 500)
        {
            var requestName = typeof(TMessage).Name;
            var userId = _user.Id ?? string.Empty;
            var userName = string.Empty;

            if (!string.IsNullOrEmpty(userId))
            {
                userName = await _identityService.GetUserNameAsync(userId);
            }

            _logger.LogWarning("CleanApi Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@UserName} {@Request}",
                requestName, elapsedMilliseconds, userId, userName, message);
        }

        return response;
    }
}
