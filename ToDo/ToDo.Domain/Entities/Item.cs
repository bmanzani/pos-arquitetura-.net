using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Entities
{
	public class Item
	{
		private Item() { }
		public Item(string description)
		{
			Id = Guid.NewGuid();
			Done = false;
			Description = description;
			CreatedAt = DateTime.Now;
		}

		public Guid Id { get; private set; }
		public string Description { get; private set; }
		public bool Done { get; private set; }
		public DateTime CreatedAt { get; private set; }
	}
}