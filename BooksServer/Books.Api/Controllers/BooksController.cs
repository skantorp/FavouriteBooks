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
    }
}
