using AutoFixture;
using Books.Api.Controllers;
using Books.BusinessLogic.DTOs;
using Books.BusinessLogic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace Books.Tests.Controllers
{
	public class RelatedDataControllerTests
	{
		private readonly Fixture _fixture;
		private RelatedDataController _sut;
		private readonly IMediator _mediator;

		public RelatedDataControllerTests()
		{
			_fixture = new Fixture();
			_mediator = Substitute.For<IMediator>();
		}

		[Fact]
		public async Task GetAuthorsTest()
		{
			var list = _fixture.Create<List<DictionaryDTO>>();
			_mediator.Send(new GetAuthorsRequest()).Returns(list);
			_sut = new RelatedDataController(_mediator);

			var result = await _sut.GetAuthors();

			var response = Assert.IsType<OkObjectResult>(result.Result);
			Assert.NotInRange<int>(response.StatusCode.GetValueOrDefault(), 400, 599);
		}

		[Fact]
		public async Task GetGenresTest()
		{
			var list = _fixture.Create<List<DictionaryDTO>>();
			_mediator.Send(new GetGenresRequest()).Returns(list);
			_sut = new RelatedDataController(_mediator);

			var result = await _sut.GetGenres();

			var response = Assert.IsType<OkObjectResult>(result.Result);
			Assert.NotInRange<int>(response.StatusCode.GetValueOrDefault(), 400, 599);
		}

		[Fact]
		public async Task GetStatusesTest()
		{
			var list = _fixture.Create<List<DictionaryDTO>>();
			_mediator.Send(new GetStatusesRequest()).Returns(list);
			_sut = new RelatedDataController(_mediator);

			var result = await _sut.GetStatuses();

			var response = Assert.IsType<OkObjectResult>(result.Result);
			Assert.NotInRange<int>(response.StatusCode.GetValueOrDefault(), 400, 599);
		}
	}
}