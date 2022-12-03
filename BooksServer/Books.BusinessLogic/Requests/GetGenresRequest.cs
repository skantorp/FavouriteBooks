using Books.BusinessLogic.DTOs;
using MediatR;

namespace Books.BusinessLogic.Requests
{
	public class GetGenresRequest : IRequest<List<DictionaryDTO>>
	{
	}
}