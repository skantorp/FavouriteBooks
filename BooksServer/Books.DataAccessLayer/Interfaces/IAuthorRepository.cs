using Books.DataAccessLayer.Entities;

namespace Books.DataAccessLayer.Interfaces
{
	public interface IAuthorRepository : IRepository<Author>
	{
		Task<List<Author>> GetAllAuthors(string name);
	}
}