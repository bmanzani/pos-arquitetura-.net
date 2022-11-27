using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Interface
{
	public interface IITemRepository
	{
		Task<IEnumerable<Item>> GetAllAsync();
		Task AddAsync(Item item);
		Task EditAsync(Guid id, string description, bool done);
		Task ExcludeAsync(Guid id);
	}
}
