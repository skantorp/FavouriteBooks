using Books.BusinessLogic.DTOs;
using MediatR;

namespace Books.BusinessLogic.Requests
{
	public class GetAuthorsRequest : IRequest<List<DictionaryDTO>>
	{
	}
}