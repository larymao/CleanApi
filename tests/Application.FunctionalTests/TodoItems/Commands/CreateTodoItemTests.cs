using CleanApi.Application.Common.Exceptions;
using CleanApi.Application.TodoItems.Commands.CreateTodoItem;
using CleanApi.Application.TodoLists.Commands.CreateTodoList;
using CleanApi.Domain.Entities;

namespace CleanApi.Application.FunctionalTests.TodoItems.Commands;

using static Testing;

public class CreateTodoItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateTodoItemCommand();

        await Should.ThrowAsync<ValidationException>(() =>
            SendAsync(command));
    }

    [Test]
    public async Task ShouldCreateTodoItem()
    {
        var userId = await RunAsDefaultUserAsync();

        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        var command = new CreateTodoItemCommand
        {
            ListId = listId,
            Title = "Tasks"
        };

        var itemId = await SendAsync(command);

        var item = await FindAsync<TodoItem>(itemId);

        item.ShouldNotBeNull();
        item!.ListId.ShouldBe(command.ListId);
        item.Title.ShouldBe(command.Title);
        item.CreatedBy.ShouldBe(userId);
        item.Created.ShouldBeInRange(DateTimeOffset.Now.AddSeconds(-1), DateTimeOffset.Now.AddSeconds(1));
        item.LastModifiedBy.ShouldBe(userId);
        item.LastModified.ShouldBeInRange(DateTimeOffset.Now.AddSeconds(-1), DateTimeOffset.Now.AddSeconds(1));
    }
}
