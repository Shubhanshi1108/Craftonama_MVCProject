using Craftonama_Razor.Data;
using Craftonama_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Craftonama_Razor.Pages.Categories
{
	[BindProperties]
	public class EditModel : PageModel
	{
		private readonly RazorApplicationDbContext _context;
		public Category? Category { get; set; }

		public EditModel(RazorApplicationDbContext context)
		{
			_context = context;
		}
		public void OnGet(int? id)
		{
			if(id!=null && id != 0)
			{
				Category = _context.Categories.Find(id);
			}
		}

		public IActionResult OnPost()
		{
			if(ModelState.IsValid)
			{
				_context.Categories.Update(Category);
				_context.SaveChanges();
				return RedirectToPage("Index");
			}
			return Page();
			
		}
	}
}
