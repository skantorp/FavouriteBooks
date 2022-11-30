using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Books.BusinessLogic.Requests
{
    public class CreateBookRequest: IRequest<Guid>
    {
        public string Name { get; set; }
        public string[] Authors { get; set; }
        public string[] Notes { get; set; }
        public Guid GenreId { get; set; }
        public Guid StatusId { get; set; }
    }
}
