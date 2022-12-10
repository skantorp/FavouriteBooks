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
	public class RelatedDataController : ControllerBase
	{
		private readonly IMediator _mediator;

		public RelatedDataController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("authors")]
		public async Task<ActionResult<List<DictionaryDTO>>> GetAuthors()
		{
			var authors = await _mediator.Send(new GetAuthors());
			return Ok(authors);
		}

		[HttpGet("genres")]
		public async Task<ActionResult<List<DictionaryDTO>>> GetGenres()
		{
			var genres = await _mediator.Send(new GetGenres());
			return Ok(genres);
		}

		[HttpGet("statuses")]
		public async Task<ActionResult<List<DictionaryDTO>>> GetStatuses()
		{
			var statuses = await _mediator.Send(new GetStatuses());
			return Ok(statuses);
		}
	}
}