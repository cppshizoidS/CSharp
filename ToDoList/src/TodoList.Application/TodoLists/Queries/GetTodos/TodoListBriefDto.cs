using TodoList.Application.Common.Mappings;

namespace TodoList.Application.TodoLists.Queries.GetTodos;

public class TodoListBriefDto : IMapFrom<Domain.Entities.TodoList>
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Colour { get; set; }
}