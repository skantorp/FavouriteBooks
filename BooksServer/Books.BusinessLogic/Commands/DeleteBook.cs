using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using MediatR;

namespace Books.BusinessLogic.Commands
{
	public class DeleteBook : IRequest<Guid>
	{
		public Guid Id { get; set; }
	}

	public class DeleteBookHandler : IRequestHandler<DeleteBook, Guid>
	{
		private readonly IRepository<Book> _bookRepository;

		public DeleteBookHandler(IRepository<Book> bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task<Guid> Handle(DeleteBook request, CancellationToken cancellationToken)
		{
			var bookToDelete = await _bookRepository.GetOne(x => x.Id == request.Id);
			await _bookRepository.Remove(bookToDelete);
			await _bookRepository.SaveChanges();

			return request.Id;
		}
	}
}