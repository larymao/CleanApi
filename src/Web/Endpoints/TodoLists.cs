using CleanApi.Application.TodoLists.Commands.CreateTodoList;
using CleanApi.Application.TodoLists.Commands.DeleteTodoList;
using CleanApi.Application.TodoLists.Commands.UpdateTodoList;
using CleanApi.Application.TodoLists.Queries.GetTodos;

namespace CleanApi.Web.Endpoints;

public class TodoLists : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetTodoLists)
            .MapPost(CreateTodoList)
            .MapPut(UpdateTodoList, "{id}")
            .MapDelete(DeleteTodoList, "{id}");
    }

    public async Task<TodosVm> GetTodoLists(ISender sender)
    {
        return await sender.Send(new GetTodosQuery());
    }

    public async Task<string> CreateTodoList(ISender sender, CreateTodoListCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateTodoList(ISender sender, string id, UpdateTodoListCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteTodoList(ISender sender, string id)
    {
        await sender.Send(new DeleteTodoListCommand(id));
        return Results.NoContent();
    }
}
