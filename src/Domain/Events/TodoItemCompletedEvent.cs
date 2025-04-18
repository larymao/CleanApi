using CleanApi.Domain.Events.Base;

namespace CleanApi.Domain.Events;

public class TodoItemCompletedEvent(TodoItem item) : BaseEvent
{
    public TodoItem Item { get; } = item;
}
