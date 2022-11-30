﻿using System.Linq.Expressions;
using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Books.DataAccessLayer.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BooksDbContext db) : base(db)
        {
        }

        public override async Task<Book> GetOne(Expression<Func<Book, bool>> predicate)
        {
            var entity = await _dbSet
                .Include(x => x.Authors)
                .ThenInclude(x => x.Author)
                .Include(x => x.Notes)
                .Where(predicate)
                .SingleOrDefaultAsync();

            return entity;
        }

        public Task<List<Book>> GetAllBooks(string name, string[] authorNames, string[] genres, string[] statuses)
        {
            IQueryable<Book> books = _dbSet
                .Include(x => x.Status)
                .Include(x => x.Genre)
                .Include(x => x.Authors)
                .ThenInclude(x => x.Author);

            if (!string.IsNullOrEmpty(name))
            {
                books = books.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            }

            if (authorNames.Any())
            {
                books = books.Where(x => x.Authors.Select(y => y.Author.Name).Intersect(authorNames).Any());
            }

            if (genres.Any())
            {
                books = books.Where(x => genres.Any(y => x.Genre.Name.ToLower() == y.ToLower()));
            }

            if (statuses.Any())
            {
                books = books.Where(x => statuses.Any(y => x.Status.Name.ToLower() == y.ToLower()));
            }

            return books
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public Task<List<Book>> GetAllBooks()
        {
            IQueryable<Book> books = _dbSet
                .Include(x => x.Status)
                .Include(x => x.Genre)
                .Include(x => x.Authors)
                .ThenInclude(x => x.Author);

            return books
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
    }
}
