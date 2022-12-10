using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using MediatR;

namespace Books.BusinessLogic.Commands
{
	public class UpdateBook : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string? Notes { get; set; }
		public Guid? AuthorId { get; set; }
		public string? AuthorName { get; set; }
		public Guid GenreId { get; set; }
		public Guid StatusId { get; set; }
	}

	public class UpdateBookHandler : IRequestHandler<UpdateBook, Guid>
	{
		private readonly IRepository<Book> _bookRepository;

		public UpdateBookHandler(IRepository<Book> bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task<Guid> Handle(UpdateBook request, CancellationToken cancellationToken)
		{
			var book = await _bookRepository.GetOne(x => x.Id == request.Id);
			book.Name = request.Name;
			book.StatusId = request.StatusId;
			book.GenreId = request.GenreId;
			book.Notes = request.Notes;

			if (request.AuthorId.HasValue)
			{
				book.Author = null;
				book.AuthorId = request.AuthorId.Value;
			}
			else
			{
				var newAuthor = new Author
				{
					Name = request.AuthorName
				};
				book.Author = newAuthor;
			}

			await _bookRepository.Update(book);
			await _bookRepository.SaveChanges();

			return book.Id;
		}
	}
}