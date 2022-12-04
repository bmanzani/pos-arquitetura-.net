using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Application.Dtos.Item;
using ToDo.Domain.Entities;

namespace ToDo.Application.AutoMapper
{
	public class ServiceProfile : Profile
	{
		public ServiceProfile()
		{
			CreateMap<Item, ItemResponseDto>().
				ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToString("dd/MM/yyyy HH:mm")));
		}

	}
}
