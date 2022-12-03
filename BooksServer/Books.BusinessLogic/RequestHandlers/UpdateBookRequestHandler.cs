﻿using Books.BusinessLogic.Requests;
using Books.DataAccessLayer.Interfaces;
using MediatR;

namespace Books.BusinessLogic.RequestHandlers
{
	public class UpdateBookRequestHandler : IRequestHandler<UpdateBookRequest, Guid>
	{
		private readonly IBookRepository _bookRepository;

		public UpdateBookRequestHandler(IBookRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public async Task<Guid> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
		{
			var book = await _bookRepository.GetOne(x => x.Id == request.Id);
			book.StatusId = request.StatusId;
			book.GenreId = request.GenreId;
			book.AuthorId = request.AuthorId;
			book.Notes = request.Notes;

			await _bookRepository.Update(book);
			await _bookRepository.SaveChanges();

			return book.Id;
		}
	}
}