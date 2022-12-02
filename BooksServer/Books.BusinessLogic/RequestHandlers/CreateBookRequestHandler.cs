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
                StatusId = request.StatusId,
                AuthorId = request.AuthorId,
                Notes = request.Notes
            };

            await _bookRepository.Add(newBook);
            await _bookRepository.SaveChanges();

            return newBook.Id;
        }
    }
}
