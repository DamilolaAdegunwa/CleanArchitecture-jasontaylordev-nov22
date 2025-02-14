﻿using ArrayApp.Application.Common.Exceptions;
using ArrayApp.Application.TodoItems.Commands.CreateTodoItem;
using ArrayApp.Application.TodoItems.Commands.UpdateTodoItem;
using ArrayApp.Application.TodoItems.Commands.UpdateTodoItemDetail;
using ArrayApp.Application.TodoLists.Commands.CreateTodoList;
using ArrayApp.Domain.Entities;
using ArrayApp.Domain.Enums;
using FluentAssertions;
using NUnit.Framework;

namespace ArrayApp.Application.IntegrationTests.TodoItems.Commands;

using static Testing;

public class UpdateTodoItemDetailTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new UpdateTodoItemCommand { Id = 99, Title = "New Title" };
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldUpdateTodoItem()
    {
        var userId = await RunAsDefaultUserAsync();

        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        var itemId = await SendAsync(new CreateTodoItemCommand
        {
            ListId = listId,
            Title = "New Item"
        });

        var command = new UpdateTodoItemDetailCommand
        {
            Id = itemId,
            ListId = listId,
            Note = "This is the note.",
            Priority = PriorityLevel.High
        };

        await SendAsync(command);

        var item = await FindAsync<TodoItem>(itemId);

        item.Should().NotBeNull();
        item!.Id.Should().Be(command.ListId);
        item.Note.Should().Be(command.Note);
        item.Priority.Should().Be(command.Priority);
        item.LastModifierUserId.Should().Be(0);
        item.LastModifierUserId.Should().Be(userId);
        item.LastModificationTime.Should().NotBeNull();
        item.LastModificationTime.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
