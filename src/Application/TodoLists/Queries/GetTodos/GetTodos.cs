using CleanApi.Application.Common.Interfaces;
using CleanApi.Application.Common.Models;
using CleanApi.Application.Common.Security;
using CleanApi.Domain.Enums;

namespace CleanApi.Application.TodoLists.Queries.GetTodos;

[Authorize]
public record GetTodosQuery : IQuery<TodosVm>;

public class GetTodosQueryHandler(
    IApplicationDbContext context)
    : IQueryHandler<GetTodosQuery, TodosVm>
{
    private readonly IApplicationDbContext _context = context;

    public async ValueTask<TodosVm> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        return new TodosVm
        {
            PriorityLevels =
            [
                .. Enum.GetValues<PriorityLevel>()
                    .Cast<PriorityLevel>()
                    .Select(p => new LookupDto { Id = ((int)p).ToString(), Title = p.ToString() })
            ],

            Lists = await _context.TodoLists
                .AsNoTracking()
                .ProjectToType<TodoListDto>()
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken)
        };
    }
}
