using Books.BusinessLogic.DTOs;
using MediatR;

namespace Books.BusinessLogic.Requests
{
	public class GetStatusesRequest : IRequest<List<DictionaryDTO>>
	{
	}
}