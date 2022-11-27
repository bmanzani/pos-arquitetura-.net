using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using ToDo.Domain.Entities;
using ToDo.Domain.Interface;
using ToDo.Web.Mvc.Models;

namespace ToDo.Web.Mvc.Controllers
{
	public class ItemController : Controller
	{
		protected IITemRepository repository;

		public ItemController(IITemRepository repository)
		{
			this.repository = repository;
		}
		public async Task<IActionResult> Index()
		{
			var items = await repository.GetAllAsync();
			return View(items);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("Description")] CreateItemModel createItemModel)
		{
			if (ModelState.IsValid)
			{
				var item = new Item(createItemModel.Description);
				await repository.AddAsync(item);
				return RedirectToAction(nameof(Index));
			}

			return View(createItemModel);
		}

		public async Task<IActionResult> Exclude(Guid id)
		{
			await repository.ExcludeAsync(id);
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
			await repository.EditAsync(editItemModel.Id, editItemModel.Description, editItemModel.Done);
			return RedirectToAction(nameof(Index));
		}
	}
}
