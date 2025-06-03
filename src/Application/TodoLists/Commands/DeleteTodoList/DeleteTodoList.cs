using CleanApi.Application.Common.Interfaces;

namespace CleanApi.Application.TodoLists.Commands.DeleteTodoList;

public record DeleteTodoListCommand(string Id) : ICommand;

public class DeleteTodoListCommandHandler(
    IApplicationDbContext context)
    : ICommandHandler<DeleteTodoListCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async ValueTask<Unit> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoLists
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.TodoLists.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
