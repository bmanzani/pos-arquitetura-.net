using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Dtos.Item;

namespace ToDo.Application.Interfaces
{
	public interface IItemAppService
	{
		Task<IEnumerable<ItemResponseDto>> GetAllAsync();

		Task AddAsync(CreateItemRequestDto dto);
		Task EditAsync(Guid id, string description, bool done);
		Task ExcludeAsync(Guid id);
	}
}
