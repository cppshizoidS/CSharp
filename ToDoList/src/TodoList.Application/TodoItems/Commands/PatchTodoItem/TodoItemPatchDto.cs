using AutoMapper;
using TodoList.Application.Common.Mappings;
using TodoList.Application.TodoItems.Queries.GetTodoItems;
using TodoList.Domain.Entities;

namespace TodoList.Application.TodoItems.Commands.PatchTodoItem;

public class TodoItemPatchDto
{
    public Guid Id { get; set; }
    public Guid ListId { get; set; }
    public string? Title { get; set; }
    public bool Done { get; set; }
}