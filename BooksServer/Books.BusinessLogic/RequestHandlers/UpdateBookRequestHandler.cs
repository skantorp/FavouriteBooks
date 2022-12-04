using Books.BusinessLogic.Requests;
using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using MediatR;

namespace Books.BusinessLogic.RequestHandlers
{
	public class UpdateBookRequestHandler : IRequestHandler<UpdateBookRequest, Guid>
	{
		private readonly IRepository<Book> _bookRepository;

		public UpdateBookRequestHandler(IRepository<Book> bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task<Guid> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
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