using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.BusinessLogic.Requests;
using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using Books.DataAccessLayer.Repositories;
using MediatR;

namespace Books.BusinessLogic.RequestHandlers
{
    public class CreateBookRequestHandler : IRequestHandler<CreateBookRequest, Guid>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public CreateBookRequestHandler(IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Guid> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            var newBook = new Book
            {
                Name = request.Name,
                GenreId = request.GenreId,
                StatusId = request.StatusId
            };

            foreach (var authorName in request.Authors)
            {
                var author = await _authorRepository.GetOne(x => x.Name == authorName);
                if (author == null)
                {
                    author = new Author
                    {
                        Name = authorName
                    };
                    newBook.Authors.Add(new BookAuthor
                    {
                        Author = author,
                        Book = newBook
                    });
                }
            }
            foreach (var note in request.Notes)
            {
                newBook.Notes.Add(new Note
                {
                    Name = note
                });
            } 

            await _bookRepository.Add(newBook);
            await _bookRepository.SaveChanges();

            return newBook.Id;
        }
    }
}
