using Books.BusinessLogic.Commands;
using Books.BusinessLogic.DTOs;
using Books.BusinessLogic.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Books.Api.Controllers
{
	[Authorize]
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
		public async Task<ActionResult<List<BookDTO>>> Get()
		{
			var books = await _mediator.Send(new GetAllBooks());
			return Ok(books);
		}

		[HttpPost]
		public async Task<ActionResult<Guid>> Create(CreateBook createBookRequest)
		{
			var result = await _mediator.Send(createBookRequest);
			return Ok(result);
		}

		[HttpPut]
		public async Task<ActionResult<Guid>> Update(UpdateBook updateBookRequest)
		{
			var result = await _mediator.Send(updateBookRequest);
			return Ok(result);
		}

		[HttpDelete]
		public async Task<ActionResult<Guid>> Delete(Guid id)
		{
			var result = await _mediator.Send(new DeleteBook
			{
				Id = id
			});
			return Ok(result);
		}
	}
}