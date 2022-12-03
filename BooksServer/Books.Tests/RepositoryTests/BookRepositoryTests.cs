using System.Linq.Expressions;
using AutoFixture;
using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using NSubstitute;

namespace Books.Tests.RepositoryTests
{
	public class BookRepositoryTests
	{
		private readonly IBookRepository _sut;
		private readonly Fixture _fixture;

		public BookRepositoryTests()
		{
			_sut = Substitute.For<IBookRepository>();
			_fixture = new Fixture();
			TestInitialize();
		}

		private void TestInitialize()
		{
			_fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
				.ForEach(b => _fixture.Behaviors.Remove(b));
			_fixture.Behaviors.Add(new OmitOnRecursionBehavior());

			var testBook = _fixture.Create<Book>();
			var books = _fixture.Create<List<Book>>();

			_sut.GetAll().Returns(books);
			_sut.GetOne(Arg.Any<Expression<Func<Book, bool>>>()).Returns(testBook);
		}

		[Fact]
		public async Task GetAllTest()
		{
			var books = await _sut.GetAll();
			Assert.NotEmpty(books);
		}

		[Fact]
		public async Task GetOneTest()
		{
			var book = await _sut.GetOne(x => x.Id == new Guid());
			Assert.NotNull(book);
		}

		[Fact]
		public async Task AddTest()
		{
			var book = _fixture.Create<Book>();

			await _sut.Add(book);

			Assert.True(true);
		}

		[Fact]
		public async Task UpdateTest()
		{
			var book = _fixture.Create<Book>();

			await _sut.Update(book);

			Assert.True(true);
		}

		[Fact]
		public async Task DeleteTest()
		{
			var book = _fixture.Create<Book>();

			await _sut.Remove(book);

			Assert.True(true);
		}
	}
}