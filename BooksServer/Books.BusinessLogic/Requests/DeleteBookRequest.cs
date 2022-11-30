using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Books.BusinessLogic.Requests
{
    public class DeleteBookRequest: IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
