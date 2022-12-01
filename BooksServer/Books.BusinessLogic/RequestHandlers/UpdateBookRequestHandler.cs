﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.BusinessLogic.Requests;
using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using MediatR;

namespace Books.BusinessLogic.RequestHandlers
{
    public class UpdateBookRequestHandler : IRequestHandler<UpdateBookRequest, Guid>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public UpdateBookRequestHandler(IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Guid> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetOne(x => x.Id == request.Id);
            book.StatusId = request.StatusId;
            book.GenreId = request.GenreId;
            book.AuthorId = request.AuthorId;

            var notesToDelete = book.Notes.ExceptBy(request.Notes, x => x.Name).ToList();
            var notesToAdd = request.Notes.Except(book.Notes.Select(x => x.Name)).ToList();

            foreach (var note in notesToDelete)
            {
                book.Notes.Remove(note);
            }

            foreach (var note in notesToAdd)
            {
                book.Notes.Add(new Note
                {
                    Name = note
                });
            }

            await _bookRepository.Update(book);
            await _bookRepository.SaveChanges();

            return book.Id;
        }
    }
}
