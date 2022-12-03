using Books.BusinessLogic.DTOs;
using MediatR;

namespace Books.BusinessLogic.Requests
{
	public class GetAllBooksRequest : IRequest<List<BookDTO>>
	{
	}

	public class SearchBooksRequest : IRequest<List<BookDTO>>
	{
		public string Name { get; set; }
		public string[] AuthorNames { get; set; }
		public string[] Genres { get; set; }
		public string[] Statuses { get; set; }
	}
}