using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using ToDo.Application.Dtos.Item;
using ToDo.Application.Interfaces;
using ToDo.Domain.Entities;
using ToDo.Domain.Interface;
using ToDo.Web.Mvc.Models;

namespace ToDo.Web.Mvc.Controllers
{
	public class ItemController : Controller
	{
		protected IItemAppService _service;

		public ItemController(IItemAppService service)
		{
			_service = service;
		}
		public async Task<IActionResult> Index()
		{
			var items = await _service.GetAllAsync();
			return View(items);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("Description")] CreateItemRequestDto dto)
		{
			if (ModelState.IsValid)
			{
				var item = new Item(dto.Description);
				await _service.AddAsync(dto);
				return RedirectToAction(nameof(Index));
			}

			return View(dto);
		}

		public async Task<IActionResult> Exclude(Guid id)
		{
			await _service.ExcludeAsync(id);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Edit(Guid Id, string Description)
		{
			EditItemModel model = new EditItemModel();
			model.Description = Description;
			model.Id= Id;
			return View(model);
		}
		public async Task<IActionResult> Editar(EditItemModel editItemModel)
		{
			await _service.EditAsync(editItemModel.Id, editItemModel.Description, editItemModel.Done);
			return RedirectToAction(nameof(Index));
		}
	}
}
