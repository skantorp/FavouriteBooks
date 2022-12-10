using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccessLayer.Entities
{
	public class User
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Salt { get; set; }
	}
}
