using AutoMapper;
using Books.BusinessLogic.DTOs;
using Books.BusinessLogic.Requests;
using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using MediatR;

namespace Books.BusinessLogic.RequestHandlers
{
	public class GetAuthorsRequestHandler : IRequestHandler<GetAuthorsRequest, List<DictionaryDTO>>
	{
		private readonly IRepository<Author> _authorRepository;
		private readonly IMapper _mapper;

		public GetAuthorsRequestHandler(IRepository<Author> authorRepository, IMapper mapper)
		{
			_authorRepository = authorRepository;
			_mapper = mapper;
		}

		public async Task<List<DictionaryDTO>> Handle(GetAuthorsRequest request, CancellationToken cancellationToken)
		{
			var authors = await _authorRepository.GetAll();
			return _mapper.Map<List<DictionaryDTO>>(authors);
		}
	}
}