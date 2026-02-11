using System.Linq.Expressions;

namespace App.Application.Common.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task InsertAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
    Task<T?> GetByIdAsync(object id);
    IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    T Update(T entity);
    void Delete(T entity);
}
