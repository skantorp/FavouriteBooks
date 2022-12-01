using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Books.DataAccessLayer.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : class
{
    Task<TEntity> GetOne(Expression<Func<TEntity, bool>> predicate);
    Task<List<TEntity>> GetAll();
    Task Add(TEntity entity);
    Task Update(TEntity entity);
    Task Remove(TEntity entity);
    Task<int> SaveChanges();
}