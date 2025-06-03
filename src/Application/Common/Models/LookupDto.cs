using CleanApi.Domain.Entities;

namespace CleanApi.Application.Common.Models;

public class LookupDto
{
    public string Id { get; init; } = default!;

    public string? Title { get; init; }

    private class Mapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TodoList, LookupDto>();
            config.NewConfig<TodoItem, LookupDto>();
        }
    }
}
