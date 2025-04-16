using CleanApi.Domain.Entities;

namespace CleanApi.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public class TodoItemBriefDto
{
    public string Id { get; init; } = default!;

    public string ListId { get; init; } = default!;

    public string? Title { get; init; }

    public bool Done { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TodoItem, TodoItemBriefDto>();
        }
    }
}
