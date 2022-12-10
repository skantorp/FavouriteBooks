using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using MediatR;

namespace Books.BusinessLogic.Commands
{
	public class CreateBookRequest : IRequest<Guid>
	{
		public string Name { get; set; }
		public string? Notes { get; set; }
		public Guid? AuthorId { get; set; }
		public string? AuthorName { get; set; }
		public Guid GenreId { get; set; }
		public Guid StatusId { get; set; }
	}

	public class CreateBookRequestHandler : IRequestHandler<CreateBookRequest, Guid>
	{
		private readonly IRepository<Book> _bookRepository;

		public CreateBookRequestHandler(IRepository<Book> bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task<Guid> Handle(CreateBookRequest request, CancellationToken cancellationToken)
		{
			var newBook = new Book
			{
				Name = request.Name,
				GenreId = request.GenreId,
				StatusId = request.StatusId,
				Notes = request.Notes
			};

			if (request.AuthorId.HasValue)
			{
				newBook.AuthorId = request.AuthorId.Value;
			}
			else
			{
				var newAuthor = new Author
				{
					Name = request.AuthorName
				};
				newBook.Author = newAuthor;
			}

			await _bookRepository.Add(newBook);
			await _bookRepository.SaveChanges();

			return newBook.Id;
		}
	}
}