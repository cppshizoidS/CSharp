using System.Linq.Expressions;

namespace TodoList.Application.Common.Interfaces;

public interface IRepository<T> where T : class
{
    IQueryable<T> GetAsQueryable();
    IQueryable<T> GetAsQueryable(ISpecification<T> spec);
    IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> condition);
    
    // 2. Interface related to the number of requests
    int Count(ISpecification<T>? spec = null);
    int Count(Expression<Func<T, bool>> condition);
    Task<int> CountAsync(ISpecification<T>? spec);

    // 3. Query Existence-Related Interfaces
    bool Any(ISpecification<T>? spec);
    bool Any(Expression<Func<T, bool>>? condition = null);
    
    // 4. Get primitive entity type data related interfaces based on conditions
    ValueTask<T?> GetAsync(object key);
    Task<T?> GetAsync(Expression<Func<T, bool>> condition);
    Task<IReadOnlyList<T>> GetAsync();
    Task<IReadOnlyList<T>> GetAsync(ISpecification<T>? spec);

    // 5. Obtain mapping entity type data-related interfaces according to conditions, including Group-related operations
    TResult? SelectFirstOrDefault<TResult>(ISpecification<T>? spec, Expression<Func<T, TResult>> selector);
    Task<TResult?> SelectFirstOrDefaultAsync<TResult>(ISpecification<T>? spec, Expression<Func<T, TResult>> selector);
    Task<IReadOnlyList<TResult>> SelectAsync<TResult>(Expression<Func<T, TResult>> selector);
    Task<IReadOnlyList<TResult>> SelectAsync<TResult>(ISpecification<T>? spec, Expression<Func<T, TResult>> selector);
    Task<IReadOnlyList<TResult>> SelectAsync<TGroup, TResult>(Expression<Func<T, TGroup>> groupExpression, Expression<Func<IGrouping<TGroup, T>, TResult>> selector, ISpecification<T>? spec = null);

    // Create Related operation interface
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    
    // Update Related operation interface
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    
    // Delete Related operation interface
    Task DeleteAsync(object key);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}