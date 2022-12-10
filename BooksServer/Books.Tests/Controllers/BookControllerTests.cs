using AutoFixture;
using Books.Api.Controllers;
using Books.BusinessLogic.Commands;
using Books.BusinessLogic.DTOs;
using Books.BusinessLogic.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace Books.Tests.Controllers
{
	public class BookControllerTests
	{
		private readonly Fixture _fixture;
		private BooksController _sut;
		private readonly IMediator _mediator;

		public BookControllerTests()
		{
			_fixture = new Fixture();
			_mediator = Substitute.For<IMediator>();
		}

		[Fact]
		public async Task GetTest()
		{
			var list = _fixture.Create<List<BookDTO>>();
			_mediator.Send(new GetAllBooksRequest()).Returns(list);
			_sut = new BooksController(_mediator);

			var result = await _sut.Get();

			var response = Assert.IsType<OkObjectResult>(result.Result);
			Assert.NotInRange(response.StatusCode.GetValueOrDefault(), 400, 599);
		}

		[Fact]
		public async Task CreateTest()
		{
			var id = _fixture.Create<Guid>();
			var request = _fixture.Create<CreateBook>();
			_mediator.Send(request).Returns(id);
			_sut = new BooksController(_mediator);

			var result = await _sut.Create(request);

			var response = Assert.IsType<OkObjectResult>(result.Result);
			Assert.NotInRange(response.StatusCode.GetValueOrDefault(), 400, 599);
		}

		[Fact]
		public async Task UpdateTest()
		{
			var request = _fixture.Create<UpdateBook>();
			_mediator.Send(request).Returns(request.Id);
			_sut = new BooksController(_mediator);

			var result = await _sut.Update(request);

			var response = Assert.IsType<OkObjectResult>(result.Result);
			Assert.NotInRange(response.StatusCode.GetValueOrDefault(), 400, 599);
		}

		[Fact]
		public async Task DeleteTest()
		{
			var id = _fixture.Create<Guid>();
			_mediator.Send(id).Returns(id);
			_sut = new BooksController(_mediator);

			var result = await _sut.Delete(id);

			var response = Assert.IsType<OkObjectResult>(result.Result);
			Assert.NotInRange(response.StatusCode.GetValueOrDefault(), 400, 599);
		}
	}
}