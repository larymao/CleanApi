using CleanApi.Application.Common.Interfaces;
using CleanApi.Domain.Entities;

namespace CleanApi.Application.TodoLists.Commands.CreateTodoList;

public record CreateTodoListCommand : IRequest<string>
{
    public string? Title { get; init; }
}

public class CreateTodoListCommandHandler(
    IApplicationDbContext context)
    : IRequestHandler<CreateTodoListCommand, string>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<string> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
    {
        var entity = new TodoList
        {
            Title = request.Title
        };

        _context.TodoLists.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
