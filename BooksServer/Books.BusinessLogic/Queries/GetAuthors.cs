using AutoMapper;
using Books.BusinessLogic.DTOs;
using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using MediatR;

namespace Books.BusinessLogic.Queries
{
	public class GetAuthors : IRequest<List<DictionaryDTO>>
	{
	}

	public class GetAuthorsHandler : IRequestHandler<GetAuthors, List<DictionaryDTO>>
	{
		private readonly IRepository<Author> _authorRepository;
		private readonly IMapper _mapper;

		public GetAuthorsHandler(IRepository<Author> authorRepository, IMapper mapper)
		{
			_authorRepository = authorRepository;
			_mapper = mapper;
		}

		public async Task<List<DictionaryDTO>> Handle(GetAuthors request, CancellationToken cancellationToken)
		{
			var authors = await _authorRepository.GetAll();
			return _mapper.Map<List<DictionaryDTO>>(authors);
		}
	}
}