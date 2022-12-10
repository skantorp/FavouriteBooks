using AutoMapper;
using Books.BusinessLogic.DTOs;
using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using MediatR;

namespace Books.BusinessLogic.Queries
{
	public class GetAllBooks : IRequest<List<BookDTO>>
	{
	}

	public class GetAllBooksHandler : IRequestHandler<GetAllBooks, List<BookDTO>>
	{
		private readonly IRepository<Book> _bookRepository;
		private readonly IMapper _mapper;

		public GetAllBooksHandler(IRepository<Book> bookRepository, IMapper mapper)
		{
			_bookRepository = bookRepository;
			_mapper = mapper;
		}

		public async Task<List<BookDTO>> Handle(GetAllBooks request, CancellationToken cancellationToken)
		{
			var books = await _bookRepository.GetAll();
			return _mapper.Map<List<BookDTO>>(books);
		}
	}
}