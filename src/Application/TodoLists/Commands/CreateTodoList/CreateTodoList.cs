using CleanApi.Application.Common.Interfaces;
using CleanApi.Domain.Entities;

namespace CleanApi.Application.TodoLists.Commands.CreateTodoList;

public record CreateTodoListCommand : ICommand<string>
{
    public string? Title { get; init; }
}

public class CreateTodoListCommandHandler(
    IApplicationDbContext context)
    : ICommandHandler<CreateTodoListCommand, string>
{
    private readonly IApplicationDbContext _context = context;

    public async ValueTask<string> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
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
