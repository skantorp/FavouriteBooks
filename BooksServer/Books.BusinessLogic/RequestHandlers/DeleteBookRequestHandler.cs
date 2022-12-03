using Books.BusinessLogic.Requests;
using Books.DataAccessLayer.Interfaces;
using MediatR;

namespace Books.BusinessLogic.RequestHandlers
{
	public class DeleteBookRequestHandler : IRequestHandler<DeleteBookRequest, Guid>
	{
		private readonly IBookRepository _bookRepository;

		public DeleteBookRequestHandler(IBookRepository bookRepository)
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