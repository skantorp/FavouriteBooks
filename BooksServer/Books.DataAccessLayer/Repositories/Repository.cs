using Books.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Books.DataAccessLayer.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
	protected readonly DbSet<TEntity> _dbSet;
	protected BooksDbContext _db;

	public Repository(BooksDbContext db)
	{
		_db = db;
		_dbSet = _db.Set<TEntity>();
	}

	public virtual async Task<TEntity> GetOne(Expression<Func<TEntity, bool>> predicate)
	{
		var entity = await _dbSet
			.Where(predicate)
			.SingleOrDefaultAsync();

		return entity;
	}

	public virtual Task<List<TEntity>> GetAll()
	{
		return _dbSet
			.ToListAsync();
	}

	public virtual Task Add(TEntity entity)
	{
		_db.Add(entity);

		return Task.CompletedTask;
	}

	public virtual Task Update(TEntity entity)
	{
		_dbSet.Update(entity);

		return Task.CompletedTask;
	}

	public virtual Task Remove(TEntity entity)
	{
		_dbSet.Remove(entity);

		return Task.CompletedTask;
	}

	public void Dispose()
	{
		_db.Dispose();
	}

	public async Task<int> SaveChanges()
	{
		return await _db.SaveChangesAsync();
	}
}