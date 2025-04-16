using CleanApi.Application.Common.Interfaces;
using CleanApi.Domain.Events;

namespace CleanApi.Application.TodoItems.Commands.DeleteTodoItem;

public record DeleteTodoItemCommand(string Id) : IRequest;

public class DeleteTodoItemCommandHandler(
    IApplicationDbContext context)
    : IRequestHandler<DeleteTodoItemCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.TodoItems.Remove(entity);

        entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
