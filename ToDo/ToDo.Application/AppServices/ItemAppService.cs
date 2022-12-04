using AutoMapper;
using ToDo.Application.Dtos.Item;
using ToDo.Application.Interfaces;
using ToDo.Domain.Entities;
using ToDo.Domain.Interface;

namespace ToDo.Application.AppServices
{
	public class ItemAppService : IItemAppService
	{
		private readonly IITemRepository _repository;
		private readonly IMapper _mapper;

		public ItemAppService(IITemRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task AddAsync(CreateItemRequestDto dto)
		{
			try
			{
				var item = new Item(dto.Description);
				await _repository.AddAsync(item);
			}
			catch (Exception)
			{
				throw;
			}
		}
		public async Task<IEnumerable<ItemResponseDto>> GetAllAsync()
		{
			try
			{
				var response = await _repository.GetAllAsync();
				return _mapper.Map<IEnumerable<ItemResponseDto>>(response);
			}
			catch (Exception)
			{
				throw;
			}
		}
		public async Task EditAsync(Guid id, string description, bool done)
		{
			try
			{
				await _repository.EditAsync(id, description, done);
			}
			catch (Exception)
			{
				throw;
			}
		}
		public async Task ExcludeAsync(Guid id)
		{
			try
			{
				await _repository.ExcludeAsync(id);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
