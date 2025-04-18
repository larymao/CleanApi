using CleanApi.Application.Common.Interfaces;

namespace CleanApi.Application.TodoItems.Commands.UpdateTodoItem;

public record UpdateTodoItemCommand : IRequest
{
    public string Id { get; init; } = default!;

    public string? Title { get; init; }

    public bool Done { get; init; }
}

public class UpdateTodoItemCommandHandler(
    IApplicationDbContext context)
    : IRequestHandler<UpdateTodoItemCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Title = request.Title;
        entity.Done = request.Done;

        _context.TodoItems.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
