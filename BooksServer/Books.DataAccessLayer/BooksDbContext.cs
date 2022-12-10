using System.Reflection;
using Books.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Books.DataAccessLayer
{
	public class BooksDbContext : DbContext
	{
		public BooksDbContext(DbContextOptions<BooksDbContext> dbOptions) : base(dbOptions)
		{
			Database.EnsureCreated();
		}

		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<BookStatus> BookStatuses { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			builder.Seed();
		}
	}
}