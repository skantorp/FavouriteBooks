using AutoFixture;
using Books.Api.Controllers;
using Books.BusinessLogic.DTOs;
using Books.BusinessLogic.Requests;
using MediatR;
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

			Assert.NotNull(result);
		}

		[Fact]
		public async Task CreateTest()
		{
			var id = _fixture.Create<Guid>();
			var request = _fixture.Create<CreateBookRequest>();
			_mediator.Send(request).Returns(id);
			_sut = new BooksController(_mediator);

			var result = await _sut.Create(request);

			Assert.NotNull(result);
		}

		[Fact]
		public async Task UpdateTest()
		{
			var request = _fixture.Create<UpdateBookRequest>();
			_mediator.Send(request).Returns(request.Id);
			_sut = new BooksController(_mediator);

			var result = await _sut.Update(request);

			Assert.NotNull(result);
		}

		[Fact]
		public async Task DeleteTest()
		{
			var id = _fixture.Create<Guid>();
			_mediator.Send(id).Returns(id);
			_sut = new BooksController(_mediator);

			var result = await _sut.Delete(id);

			Assert.NotNull(result);
		}
	}
}