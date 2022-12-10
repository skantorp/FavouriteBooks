using AutoMapper;
using Books.BusinessLogic.DTOs;
using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using MediatR;

namespace Books.BusinessLogic.Queries
{
	public class GetGenresRequest : IRequest<List<DictionaryDTO>>
	{
	}

	public class GetGenresRequestHandler : IRequestHandler<GetGenresRequest, List<DictionaryDTO>>
	{
		private readonly IRepository<Genre> _genreRepository;
		private readonly IMapper _mapper;

		public GetGenresRequestHandler(IRepository<Genre> genreRepository, IMapper mapper)
		{
			_genreRepository = genreRepository;
			_mapper = mapper;
		}

		public async Task<List<DictionaryDTO>> Handle(GetGenresRequest request, CancellationToken cancellationToken)
		{
			var genres = await _genreRepository.GetAll();
			return _mapper.Map<List<DictionaryDTO>>(genres);
		}
	}
}