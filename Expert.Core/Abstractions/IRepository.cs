using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expert.Core.Abstractions;

public interface IRepository<TKey, TEntity> 
    where TKey : IConvertible 
    where TEntity : DbModel<TKey> 
{
    IQueryable<TEntity> AsQueryable();
    Task<TEntity?> GetAsync(TKey id);
    Task<bool> AddAsync(TEntity? entity);
    Task<bool> AddRangeAsync(IEnumerable<TEntity> entities);
    Task<bool> RemoveAsync(TKey id);
    Task<bool> RemoveAsync(TEntity? entity);
    Task<bool> RemoveRangeAsync(IEnumerable<TEntity> entity);
    Task UpdateAsync(TEntity? entity);
    Task UpdateRange(IEnumerable<TEntity> entities);
    Task SaveChangesAsync();
}
