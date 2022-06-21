using AutoMapper;
using TodoList.Application.Common.Mappings;
using TodoList.Domain.Entities;

namespace TodoList.Application.TodoItems.Queries.GetTodoItems;

public class TodoItemDto : IMapFrom<TodoItem>
{
    public Guid Id { get; set; }

    public Guid ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }

    public int Priority { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<TodoItem, TodoItemDto>()
            .ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority));
        
        profile.CreateMap<TodoItem, TodoItemDto>()
            .ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority))
            .ReverseMap();
    }
}