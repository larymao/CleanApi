using CleanApi.Domain.Entities;

namespace CleanApi.Application.Common.Models;

public class LookupDto
{
    public string Id { get; init; } = default!;

    public string? Title { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TodoList, LookupDto>();
            CreateMap<TodoItem, LookupDto>();
        }
    }
}
