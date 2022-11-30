using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Books.BusinessLogic.DTOs;
using Books.BusinessLogic.Requests;
using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using MediatR;

namespace Books.BusinessLogic.RequestHandlers
{
    public class SearchBooksRequestHandler : IRequestHandler<SearchBooksRequest, List<BookDTO>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public SearchBooksRequestHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<BookDTO>> Handle(SearchBooksRequest request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllBooks(request.Name, request.AuthorNames, request.Genres, request.Statuses);
            return _mapper.Map<List<BookDTO>>(books);
        }
    }
}
