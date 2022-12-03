using MediatR;

namespace Books.BusinessLogic.Requests
{
	public class UpdateBookRequest : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string? Notes { get; set; }
		public Guid? AuthorId { get; set; }
		public string? AuthorName { get; set; }
		public Guid GenreId { get; set; }
		public Guid StatusId { get; set; }
	}
}