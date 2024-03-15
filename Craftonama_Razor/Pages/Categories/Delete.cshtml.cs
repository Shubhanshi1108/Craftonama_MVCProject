using Craftonama_Razor.Data;
using Craftonama_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Craftonama_Razor.Pages.Categories
{
	[BindProperties]
    public class DeleteModel : PageModel
    {
		private readonly RazorApplicationDbContext _context;
		public Category? Category { get; set; }

		public DeleteModel(RazorApplicationDbContext context)
		{
			_context = context;
		}
		public void OnGet(int? id)
		{
			if (id != null && id != 0)
			{
				Category = _context.Categories.Find(id);
			}
		}

		public IActionResult OnPost()
		{
			Category? obj = _context.Categories.Find(Category.CategoryId);
			if (obj == null)
			{
				return NotFound();
			}
			_context.Categories.Remove(obj);	
			_context.SaveChanges();
			return RedirectToPage("index");
		}
	}
}
