using CleanApi.Application.Common.Interfaces;
using CleanApi.Application.Common.Models;
using CleanApi.Application.Common.Security;
using CleanApi.Domain.Enums;

namespace CleanApi.Application.TodoLists.Queries.GetTodos;

[Authorize]
public record GetTodosQuery : IRequest<TodosVm>;

public class GetTodosQueryHandler(
    IApplicationDbContext context)
    : IRequestHandler<GetTodosQuery, TodosVm>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<TodosVm> Handle(GetTodosQuery request, CancellationToken cancellationToken)
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
