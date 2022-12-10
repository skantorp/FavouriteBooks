using AutoMapper;
using Books.BusinessLogic.DTOs;
using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using MediatR;

namespace Books.BusinessLogic.Queries
{
	public class GetGenres : IRequest<List<DictionaryDTO>>
	{
	}

	public class GetGenresHandler : IRequestHandler<GetGenres, List<DictionaryDTO>>
	{
		private readonly IRepository<Genre> _genreRepository;
		private readonly IMapper _mapper;

		public GetGenresHandler(IRepository<Genre> genreRepository, IMapper mapper)
		{
			_genreRepository = genreRepository;
			_mapper = mapper;
		}

		public async Task<List<DictionaryDTO>> Handle(GetGenres request, CancellationToken cancellationToken)
		{
			var genres = await _genreRepository.GetAll();
			return _mapper.Map<List<DictionaryDTO>>(genres);
		}
	}
}