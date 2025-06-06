using CleanApi.Application.Common.Interfaces;

namespace CleanApi.Application.TodoLists.Commands.UpdateTodoList;

public record UpdateTodoListCommand : ICommand
{
    public string Id { get; init; } = default!;

    public string? Title { get; init; }
}

public class UpdateTodoListCommandHandler(
    IApplicationDbContext context)
    : ICommandHandler<UpdateTodoListCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async ValueTask<Unit> Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoLists
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Title = request.Title;

        _context.TodoLists.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
