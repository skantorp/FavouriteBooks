using AutoMapper;
using Books.BusinessLogic.DTOs;
using Books.BusinessLogic.Requests;
using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using MediatR;

namespace Books.BusinessLogic.RequestHandlers
{
	public class GetAllBooksRequestHandler : IRequestHandler<GetAllBooksRequest, List<BookDTO>>
	{
		private readonly IRepository<Book> _bookRepository;
		private readonly IMapper _mapper;

		public GetAllBooksRequestHandler(IRepository<Book> bookRepository, IMapper mapper)
		{
			_bookRepository = bookRepository;
			_mapper = mapper;
		}

		public async Task<List<BookDTO>> Handle(GetAllBooksRequest request, CancellationToken cancellationToken)
		{
			var books = await _bookRepository.GetAll();
			return _mapper.Map<List<BookDTO>>(books);
		}
	}
}