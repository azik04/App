using System.Linq.Expressions;

namespace App.Application.Common.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task InsertAsync(T entity, CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default,params Expression<Func<T, object>>[] includes);

    Task<T?> GetByIdAsync(object id, Func<IQueryable<T>, IQueryable<T>>? include = null, CancellationToken cancellationToken = default);
   
    IQueryable<T> Where(Expression<Func<T, bool>> predicate);

    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    Task<T> Update(T entity, CancellationToken cancellationToken = default);

    Task Delete(T entity, CancellationToken cancellationToken = default);
}