﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccessLayer.Entities
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Book> Books { get; set; }
        = new List<Book>();
    }
}
