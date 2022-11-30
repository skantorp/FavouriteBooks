using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccessLayer.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
