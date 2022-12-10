using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using MediatR;

namespace Books.BusinessLogic.Commands
{
	public class DeleteBookRequest : IRequest<Guid>
	{
		public Guid Id { get; set; }
	}

	public class DeleteBookRequestHandler : IRequestHandler<DeleteBookRequest, Guid>
	{
		private readonly IRepository<Book> _bookRepository;

		public DeleteBookRequestHandler(IRepository<Book> bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task<Guid> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
		{
			var bookToDelete = await _bookRepository.GetOne(x => x.Id == request.Id);
			await _bookRepository.Remove(bookToDelete);
			await _bookRepository.SaveChanges();

			return request.Id;
		}
	}
}