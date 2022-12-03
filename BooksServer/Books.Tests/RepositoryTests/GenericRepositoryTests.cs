using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoFixture;
using Books.DataAccessLayer.Entities;
using Books.DataAccessLayer.Interfaces;
using NSubstitute;

namespace Books.Tests.RepositoryTests
{
	public class GenericRepositoryTests
	{
		private readonly IRepository<Author> _sut;
		private readonly Fixture _fixture;

		public GenericRepositoryTests()
		{
			_sut = Substitute.For<IRepository<Author>>();
			_fixture = new Fixture();
			TestInitialize();
		}

		private void TestInitialize()
		{
			_fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
				.ForEach(b => _fixture.Behaviors.Remove(b));
			_fixture.Behaviors.Add(new OmitOnRecursionBehavior());

			var testAuthor = _fixture.Create<Author>();
			var authors = _fixture.Create<List<Author>>();

			_sut.GetAll().Returns(authors);
			_sut.GetOne(Arg.Any<Expression<Func<Author, bool>>>()).Returns(testAuthor);
		}

		[Fact]
		public async Task GetAllTest()
		{
			var authors = await _sut.GetAll();

			Assert.NotEmpty(authors);
		}

		[Fact]
		public async Task GetOneTest()
		{
			var author = await _sut.GetOne(x => x.Id == new Guid());

			Assert.NotNull(author);
		}

		[Fact]
		public async Task AddTest()
		{
			var author = _fixture.Create<Author>();

			await _sut.Add(author);

			Assert.True(true);
		}

		[Fact]
		public async Task UpdateTest()
		{
			var author = _fixture.Create<Author>();

			await _sut.Update(author);

			Assert.True(true);
		}

		[Fact]
		public async Task DeleteTest()
		{
			var author = _fixture.Create<Author>();

			await _sut.Remove(author);

			Assert.True(true);
		}
	}
}