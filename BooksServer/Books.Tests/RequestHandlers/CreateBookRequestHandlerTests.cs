using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.BusinessLogic.RequestHandlers;
using Books.BusinessLogic.Requests;
using NSubstitute;

namespace Books.Tests.RequestHandlers
{
    public class CreateBookRequestHandlerTests
    {
        [Fact]
        public void CreateTest()
        {
            var sut = Substitute.For<CreateBookRequestHandler>();
            var tt= Arg.Any<CreateBookRequest>();

            sut.Handle(tt, CancellationToken.None);
            sut.Received();
        }
    }
}
