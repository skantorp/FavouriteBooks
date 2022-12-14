namespace Books.BusinessLogic.DTOs
{
	public class BookDTO
	{
		public Guid Id { get; set; }
		public string? Name { get; set; }
		public DictionaryDTO Status { get; set; }
		public DictionaryDTO Genre { get; set; }
		public DictionaryDTO Author { get; set; }
		public string? Notes { get; set; }
	}
}