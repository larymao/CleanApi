using CleanApi.Application.Common.Exceptions;
using CleanApi.Application.TodoLists.Commands.CreateTodoList;
using CleanApi.Application.TodoLists.Commands.UpdateTodoList;
using CleanApi.Domain.Entities;

namespace CleanApi.Application.FunctionalTests.TodoLists.Commands;

using static Testing;

public class UpdateTodoListTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        var command = new UpdateTodoListCommand { Id = "ffffffff-ffff-ffff-ffff-ffffffffffff", Title = "New Title" };
        await Should.ThrowAsync<NotFoundException>(() => SendAsync(command));
    }

    [Test]
    public async Task ShouldRequireUniqueTitle()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        await SendAsync(new CreateTodoListCommand
        {
            Title = "Other List"
        });

        var command = new UpdateTodoListCommand
        {
            Id = listId,
            Title = "Other List"
        };

        (await Should.ThrowAsync<ValidationException>(() => SendAsync(command)))
            .Errors.Keys.ShouldContain("Title");
        (await Should.ThrowAsync<ValidationException>(() => SendAsync(command)))
            .Errors["Title"].ShouldContain("'Title' must be unique.");
    }

    [Test]
    public async Task ShouldUpdateTodoList()
    {
        var userId = await RunAsDefaultUserAsync();

        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        var command = new UpdateTodoListCommand
        {
            Id = listId,
            Title = "Updated List Title"
        };

        await SendAsync(command);

        var list = await FindAsync<TodoList>(listId);

        list.ShouldNotBeNull();
        list!.Title.ShouldBe(command.Title);
        list.LastModifiedBy.ShouldNotBeNull();
        list.LastModifiedBy.ShouldBe(userId);
        list.LastModified.ShouldBeInRange(DateTimeOffset.Now.AddSeconds(-1), DateTimeOffset.Now.AddSeconds(1));
    }
}
