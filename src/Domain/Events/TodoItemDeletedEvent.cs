using CleanApi.Domain.Events.Base;

namespace CleanApi.Domain.Events;

public class TodoItemDeletedEvent(TodoItem item) : BaseEvent
{
    public TodoItem Item { get; } = item;
}
