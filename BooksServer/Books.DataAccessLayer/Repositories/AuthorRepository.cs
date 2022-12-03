using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Books.DataAccessLayer.Repositories
{
	public class AuthorRepository : Repository<Author>, IAuthorRepository
	{
		public AuthorRepository(BooksDbContext db) : base(db)
		{
		}

		public Task<List<Author>> GetAllAuthors(string name)
		{
			return _dbSet
				.Where(x => x.Name.ToLower().Contains(name.ToLower()))
				.ToListAsync();
		}
	}
}