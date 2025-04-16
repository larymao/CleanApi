using CleanApi.Application.Common.Interfaces;
using CleanApi.Domain.Enums;

namespace CleanApi.Application.TodoItems.Commands.UpdateTodoItemDetail;

public record UpdateTodoItemDetailCommand : IRequest
{
    public string Id { get; init; } = default!;

    public string ListId { get; init; } = default!;

    public PriorityLevel Priority { get; init; }

    public string? Note { get; init; }
}

public class UpdateTodoItemDetailCommandHandler(
    IApplicationDbContext context)
    : IRequestHandler<UpdateTodoItemDetailCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async Task Handle(UpdateTodoItemDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.ListId = request.ListId;
        entity.Priority = request.Priority;
        entity.Note = request.Note;

        _context.TodoItems.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
