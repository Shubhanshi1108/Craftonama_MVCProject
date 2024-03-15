using Craftonama_Razor.Data;
using Craftonama_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Craftonama_Razor.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly RazorApplicationDbContext _context;
		public Category Category { get; set; }

		public CreateModel(RazorApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _context.Categories.Add(Category);   
            _context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
