using MediatR;

namespace Books.BusinessLogic.Requests
{
	public class DeleteBookRequest : IRequest<Guid>
	{
		public Guid Id { get; set; }
	}
}