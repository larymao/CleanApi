using CleanApi.Domain.Events;
using Microsoft.Extensions.Logging;

namespace CleanApi.Application.TodoItems.EventHandlers;

public class TodoItemCompletedEventHandler(
    ILogger<TodoItemCompletedEventHandler> logger)
    : INotificationHandler<TodoItemCompletedEvent>
{
    private readonly ILogger<TodoItemCompletedEventHandler> _logger = logger;

    public ValueTask Handle(TodoItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CleanApi Domain Event: {DomainEvent}", notification.GetType().Name);

        return ValueTask.CompletedTask;
    }
}
