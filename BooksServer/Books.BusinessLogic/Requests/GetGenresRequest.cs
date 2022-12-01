using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.BusinessLogic.DTOs;
using MediatR;

namespace Books.BusinessLogic.Requests
{
    public class GetGenresRequest : IRequest<List<DictionaryDTO>>
    {

    }
}
