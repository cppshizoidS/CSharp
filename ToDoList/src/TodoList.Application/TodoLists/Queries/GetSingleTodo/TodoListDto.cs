using TodoList.Application.Common.Mappings;
using TodoList.Application.TodoItems.Queries.GetTodoItems;

namespace TodoList.Application.TodoLists.Queries.GetSingleTodo;

public class TodoListDto : IMapFrom<Domain.Entities.TodoList>
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Colour { get; set; }

    public IList<TodoItemDto> Items { get; set; } = new List<TodoItemDto>();
}
