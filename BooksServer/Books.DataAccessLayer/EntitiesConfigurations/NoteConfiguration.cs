using Books.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Books.DataAccessLayer.EntitiesConfigurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Book)
                .WithMany(x => x.Notes)
                .HasForeignKey(x => x.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
