using CleanApi.Domain.Events.Base;

namespace CleanApi.Domain.Events;

public class TodoItemCreatedEvent(TodoItem item) : BaseEvent
{
    public TodoItem Item { get; } = item;
}
