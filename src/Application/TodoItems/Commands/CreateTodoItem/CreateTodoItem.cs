using CleanApi.Application.Common.Interfaces;
using CleanApi.Domain.Entities;
using CleanApi.Domain.Events;

namespace CleanApi.Application.TodoItems.Commands.CreateTodoItem;

public record CreateTodoItemCommand : ICommand<string>
{
    public string ListId { get; init; } = default!;

    public string? Title { get; init; }
}

public class CreateTodoItemCommandHandler(
    IApplicationDbContext context)
    : ICommandHandler<CreateTodoItemCommand, string>
{
    private readonly IApplicationDbContext _context = context;

    public async ValueTask<string> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new TodoItem
        {
            ListId = request.ListId,
            Title = request.Title,
            Done = false
        };

        entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

        _context.TodoItems.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
