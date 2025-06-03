using CleanApi.Application.Common.Interfaces;
using CleanApi.Application.Common.Security;
using CleanApi.Domain.Constants;

namespace CleanApi.Application.TodoLists.Commands.PurgeTodoLists;

[Authorize(Roles = Roles.Administrator)]
[Authorize(Policy = Policies.CanPurge)]
public record PurgeTodoListsCommand : ICommand;

public class PurgeTodoListsCommandHandler(
    IApplicationDbContext context)
    : ICommandHandler<PurgeTodoListsCommand>
{
    private readonly IApplicationDbContext _context = context;

    public async ValueTask<Unit> Handle(PurgeTodoListsCommand request, CancellationToken cancellationToken)
    {
        _context.TodoLists.RemoveRange(_context.TodoLists);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
