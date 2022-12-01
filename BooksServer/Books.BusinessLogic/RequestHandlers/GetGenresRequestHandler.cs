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
using Books.DataAccessLayer.Repositories;
using MediatR;

namespace Books.BusinessLogic.RequestHandlers
{
    public class GetGenresRequestHandler : IRequestHandler<GetGenresRequest, List<DictionaryDTO>>
    {
        private readonly IRepository<Genre> _genreRepository;
        private readonly IMapper _mapper;

        public GetGenresRequestHandler(IRepository<Genre> genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        public async Task<List<DictionaryDTO>> Handle(GetGenresRequest request, CancellationToken cancellationToken)
        {
            var genres = await _genreRepository.GetAll();
            return _mapper.Map<List<DictionaryDTO>>(genres);
        }
    }
}
