using CleanApi.Application.Common.Interfaces;
using CleanApi.Application.Common.Models;
using CleanApi.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using CleanApi.Application.TodoLists.Queries.GetTodos;
using CleanApi.Domain.Entities;
using Mapster;
using NUnit.Framework;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CleanApi.Application.UnitTests.Common.Mappings;

public class MappingTests
{
    private readonly TypeAdapterConfig _config;

    public MappingTests()
    {
        _config = TypeAdapterConfig.GlobalSettings;
        _config.Scan(Assembly.GetAssembly(typeof(IApplicationDbContext))!);
    }

    [Test]
    public void ShouldHaveValidConfiguration()
    {
        _config.Compile();
    }

    [Test]
    [TestCase(typeof(TodoList), typeof(TodoListDto))]
    [TestCase(typeof(TodoItem), typeof(TodoItemDto))]
    [TestCase(typeof(TodoList), typeof(LookupDto))]
    [TestCase(typeof(TodoItem), typeof(LookupDto))]
    [TestCase(typeof(TodoItem), typeof(TodoItemBriefDto))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);

        instance.Adapt(source, destination, _config);
    }

    private static object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;

        // Type without parameterless constructor
        return RuntimeHelpers.GetUninitializedObject(type);
    }
}
