using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.BusinessLogic.DTOs
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DictionaryDTO Status { get; set; }
        public DictionaryDTO Genre { get; set; }
        public List<DictionaryDTO> Notes { get; set; }
        = new List<DictionaryDTO>();
        public List<DictionaryDTO> Authors { get; set; }
        = new List<DictionaryDTO>();
    }
}
