using Books.BusinessLogic.DTOs;
using Books.BusinessLogic.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<BookDTO>> Get()
        {
            var tt = await _mediator.Send(new GetAllBooksRequest());
            return tt;
        }       

        [HttpPost]
        public async Task<Guid> Create(CreateBookRequest createBookRequest)
        {
            var result = await _mediator.Send(createBookRequest);
            return result;
        }

        [HttpPut]
        public async Task<Guid> Update(UpdateBookRequest updateBookRequest)
        {
            var result = await _mediator.Send(updateBookRequest);
            return result;
        }

        [HttpDelete]
        public async Task<Guid> Delete(DeleteBookRequest deleteBookRequest)
        {
            var result = await _mediator.Send(deleteBookRequest);
            return result;
        }
    }
}
