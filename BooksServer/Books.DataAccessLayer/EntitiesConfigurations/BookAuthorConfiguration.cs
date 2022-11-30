using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Books.DataAccessLayer.EntitiesConfigurations
{
    public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasKey(x => new { x.AuthorId, x.BookId });

            builder.HasOne(e => e.Author)
            .WithMany(e => e.Books)
            .HasForeignKey(e => e.AuthorId);

            builder.HasOne(e => e.Book)
                .WithMany(e => e.Authors)
                .HasForeignKey(e => e.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
