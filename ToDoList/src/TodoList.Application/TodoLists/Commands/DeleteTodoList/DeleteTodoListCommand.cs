using MediatR;
using TodoList.Application.Common.Exceptions;
using TodoList.Application.Common.Interfaces;

namespace TodoList.Application.TodoLists.Commands.DeleteTodoList;

public class DeleteTodoListCommand : IRequest
{
    public Guid Id { get; set; }
}

public class DeleteTodoListCommandHandler : IRequestHandler<DeleteTodoListCommand>
{
    private readonly IRepository<Domain.Entities.TodoList> _repository;

    public DeleteTodoListCommandHandler(IRepository<Domain.Entities.TodoList> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(request.Id);
        if (entity == null)
        {
            throw new NotFoundException(nameof(TodoList), request.Id);
        }

        await _repository.DeleteAsync(entity,cancellationToken);
        
        return Unit.Value;
    }
}