namespace ToDo.Web.Mvc.Models
{
	public class EditItemModel
	{
		public Guid Id { get; set; }
		public string Description { get; set; }
		public bool Done { get; set; }
	}
}
