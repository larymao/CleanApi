using Microsoft.Extensions.Logging;

namespace CleanApi.Application.Common.Behaviours;

public class UnhandledExceptionBehaviour<TMessage, TResponse>(
    ILogger<TMessage> logger)
    : IPipelineBehavior<TMessage, TResponse> where TMessage : IMessage
{
    private readonly ILogger<TMessage> _logger = logger;

    public async ValueTask<TResponse> Handle(TMessage message, CancellationToken cancellationToken, MessageHandlerDelegate<TMessage, TResponse> next)
    {
        try
        {
            return await next(message, cancellationToken);
        }
        catch (Exception ex)
        {
            var requestName = typeof(TMessage).Name;

            _logger.LogError(ex, "CleanApi Request: Unhandled Exception for Request {Name} {@Request}", requestName, message);

            throw;
        }
    }
}
