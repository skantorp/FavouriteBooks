using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.DataAccessLayer.Entities;

namespace Books.DataAccessLayer.Interfaces
{
    public interface IAuthorRepository: IRepository<Author>
    {
        Task<List<Author>> GetAllAuthors(string name);
    }
}
