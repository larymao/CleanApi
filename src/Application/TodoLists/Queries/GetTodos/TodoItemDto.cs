using CleanApi.Domain.Entities;

namespace CleanApi.Application.TodoLists.Queries.GetTodos;

public class TodoItemDto
{
    public string Id { get; init; } = default!;

    public string ListId { get; init; } = default!;

    public string? Title { get; init; }

    public bool Done { get; init; }

    public int Priority { get; init; }

    public string? Note { get; init; }

    private class Mapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TodoItem, TodoItemDto>()
                .Map(dest => dest.Priority, src => (int)src.Priority);
        }
    }
}
