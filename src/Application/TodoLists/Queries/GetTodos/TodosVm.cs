using CleanApi.Application.Common.Models;

namespace CleanApi.Application.TodoLists.Queries.GetTodos;

public class TodosVm
{
    public IReadOnlyCollection<LookupDto> PriorityLevels { get; init; } = [];

    public IReadOnlyCollection<TodoListDto> Lists { get; init; } = [];
}
