using AutoMapper;
using Books.BusinessLogic.DTOs;
using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using MediatR;

namespace Books.BusinessLogic.Queries
{
	public class GetStatusesRequest : IRequest<List<DictionaryDTO>>
	{
	}

	public class GetStatusesRequestHandler : IRequestHandler<GetStatusesRequest, List<DictionaryDTO>>
	{
		private readonly IRepository<BookStatus> _statusRepository;
		private readonly IMapper _mapper;

		public GetStatusesRequestHandler(IRepository<BookStatus> statusRepository, IMapper mapper)
		{
			_statusRepository = statusRepository;
			_mapper = mapper;
		}

		public async Task<List<DictionaryDTO>> Handle(GetStatusesRequest request, CancellationToken cancellationToken)
		{
			var statuses = await _statusRepository.GetAll();
			return _mapper.Map<List<DictionaryDTO>>(statuses);
		}
	}
}