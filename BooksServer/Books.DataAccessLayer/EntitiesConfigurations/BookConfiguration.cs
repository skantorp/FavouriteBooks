using Books.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Books.DataAccessLayer.EntitiesConfigurations
{
	public class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.HasKey(x => x.Id);

			builder.HasOne(x => x.Genre)
				.WithMany(x => x.Books)
				.HasForeignKey(x => x.GenreId);

			builder.HasOne(x => x.Status)
				.WithMany(x => x.Books)
				.HasForeignKey(x => x.StatusId);

			builder.HasOne(x => x.Author)
				.WithMany(x => x.Books)
				.HasForeignKey(x => x.AuthorId);
		}
	}
}