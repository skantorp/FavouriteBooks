using Books.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Books.DataAccessLayer
{
	public static class InitialDataSeed
	{
		public static void Seed(this ModelBuilder builder)
		{
			builder.Entity<BookStatus>().HasData(
				new BookStatus
				{
					Id = new Guid("70E3159B-B9A7-46DD-A17C-02245EC43370"),
					Name = "Unknown"
				},
				new BookStatus
				{
					Id = new Guid("462B3AAF-4F22-4ACA-88E4-F9191DA97563"),
					Name = "Planning to read"
				},
				new BookStatus
				{
					Id = new Guid("4F759959-BCCF-41F1-823A-ECC5EDE9EA0E"),
					Name = "Currently reading"
				},
				new BookStatus
				{
					Id = new Guid("B17D42AF-A804-4667-AE1D-171FA1129D5A"),
					Name = "Already read"
				}
			);

			builder.Entity<Genre>().HasData(
				new Genre
				{
					Id = new Guid("8A6BAD8F-4286-457E-8EDF-A82C82C43FE0"),
					Name = "History"
				},
				new Genre
				{
					Id = new Guid("5FC593C0-9BAA-4A9F-A9ED-4F21489C14F0"),
					Name = "Fantasy"
				},
				new Genre
				{
					Id = new Guid("FB51DB69-9AAD-4CA1-8634-A1C2AB19A203"),
					Name = "Science"
				},
				new Genre
				{
					Id = new Guid("E509DB6B-0F04-4B1F-83D0-EB8D6F2D6D7E"),
					Name = "Drama"
				},
				new Genre
				{
					Id = new Guid("4E5D42CC-7FDF-4507-B65D-6BF1A9AFA334"),
					Name = "Biography"
				}
			);

			builder.Entity<Author>().HasData(
				new Author
				{
					Id = new Guid("B776DB53-A7DB-487A-82A4-A959FA56C58D"),
					Name = "William Shakespeare"
				},
				new Author
				{
					Id = new Guid("152BA060-CE13-4997-A8D1-EFE6AEF1EA98"),
					Name = "Henrik Meinander"
				},
				new Author
				{
					Id = new Guid("BEF93CE5-9BF1-4B19-A6A8-5C7DFF1E24B4"),
					Name = "Martin Gilbert"
				},
				new Author
				{
					Id = new Guid("F2997F3C-6C2F-4F6A-9D23-3AEA8DB4AD67"),
					Name = "Michio Kaku"
				}
			);

			builder.Entity<Book>().HasData(
				new Book
				{
					Id = new Guid("2FE13138-4570-4818-889F-A6113E6AF38C"),
					Name = "Churchill: A Life",
					GenreId = new Guid("4E5D42CC-7FDF-4507-B65D-6BF1A9AFA334"),
					StatusId = new Guid("70E3159B-B9A7-46DD-A17C-02245EC43370"),
					AuthorId = new Guid("BEF93CE5-9BF1-4B19-A6A8-5C7DFF1E24B4")
				},
				new Book
				{
					Id = new Guid("A43AF29D-6860-4949-A364-B373FC34F0D8"),
					Name = "History of Finland",
					GenreId = new Guid("4E5D42CC-7FDF-4507-B65D-6BF1A9AFA334"),
					StatusId = new Guid("B17D42AF-A804-4667-AE1D-171FA1129D5A"),
					AuthorId = new Guid("152BA060-CE13-4997-A8D1-EFE6AEF1EA98")
				},
				new Book
				{
					Id = new Guid("3A0A19F3-E347-41B7-AB41-FADECBB7A767"),
					Name = "Physics of the Future",
					GenreId = new Guid("FB51DB69-9AAD-4CA1-8634-A1C2AB19A203"),
					StatusId = new Guid("4F759959-BCCF-41F1-823A-ECC5EDE9EA0E"),
					AuthorId = new Guid("F2997F3C-6C2F-4F6A-9D23-3AEA8DB4AD67")
				},
				new Book
				{
					Id = new Guid("8A6EE85F-A71A-4075-BF06-B08B418CB0D8"),
					Name = "Romeo and Juliet",
					GenreId = new Guid("E509DB6B-0F04-4B1F-83D0-EB8D6F2D6D7E"),
					StatusId = new Guid("462B3AAF-4F22-4ACA-88E4-F9191DA97563"),
					AuthorId = new Guid("B776DB53-A7DB-487A-82A4-A959FA56C58D")
				}
			);

			builder.Entity<User>().HasData(
				new User
				{
					Id = new Guid("AF79443A-7C9E-43A5-8A3B-E86FF303F512"),
					Name = "Yaroslav Melnyk",
					Username = "user",
					Password = "y/YjOg4ktWpidOPQ50PiE7RVTvckCG5pnEgX0+Y8P7T9+m8+nW0yOUvCAGaCra/cq4FkI9JcKk53hO52GuDfoA==",
					Salt = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855"
				}
			);
		}
	}
}