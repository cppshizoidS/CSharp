using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoList.Application.Common.Interfaces;
using TodoList.Domain.Base;
using TodoList.Domain.Base.Interfaces;
using TodoList.Domain.Entities;
using TodoList.Infrastructure.Identity;

namespace TodoList.Infrastructure.Persistence;
public class TodoListDbContext : IdentityDbContext<ApplicationUser>
{
    private readonly IDomainEventService _domainEventService;
    private readonly ICurrentUserService _currentUserService;

    public TodoListDbContext(
        DbContextOptions<TodoListDbContext> options,
        IDomainEventService domainEventService,
        ICurrentUserService currentUserService) : base(options)
    {
        _domainEventService = domainEventService;
        _currentUserService = currentUserService;
    }

    public DbSet<Domain.Entities.TodoList> TodoLists => Set<Domain.Entities.TodoList>();
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _currentUserService.UserName;
                    entry.Entity.Created = DateTime.UtcNow;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = _currentUserService.UserName;
                    entry.Entity.LastModified = DateTime.UtcNow;
                    break;
            }
        }

        var events = ChangeTracker.Entries<IHasDomainEvent>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .Where(domainEvent => !domainEvent.IsPublished)
                .ToArray();

        var result = await base.SaveChangesAsync(cancellationToken);

        await DispatchEvents(events);

        return result;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    private async Task DispatchEvents(DomainEvent[] events)
    {
        foreach (var @event in events)
        {
            @event.IsPublished = true;
            await _domainEventService.Publish(@event);
        }
    }
}