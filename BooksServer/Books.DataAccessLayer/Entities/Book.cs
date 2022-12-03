namespace Books.DataAccessLayer.Entities
{
	public class Book
	{
		public Guid Id { get; set; }
		public string? Name { get; set; }
		public Guid StatusId { get; set; }
		public BookStatus Status { get; set; }
		public Guid GenreId { get; set; }
		public Genre Genre { get; set; }
		public Guid AuthorId { get; set; }
		public Author Author { get; set; }
		public string? Notes { get; set; }
	}
}