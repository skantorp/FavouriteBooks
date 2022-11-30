using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccessLayer.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookAuthor> Books { get; set; }
        = new List<BookAuthor>();
    }
}
