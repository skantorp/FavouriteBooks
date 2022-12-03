using Books.DataAccessLayer.Entities;

namespace Books.DataAccessLayer.Interfaces
{
	public interface IBookRepository : IRepository<Book>
	{
		Task<List<Book>> GetAllBooks(string name, string[] authorNames, string[] genres, string[] statuses);
	}
}