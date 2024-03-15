using Craftonama_Razor.Data;
using Craftonama_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace Craftonama_Razor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly RazorApplicationDbContext _db;
        public List<Category> CategoryList { get; set; }
        public IndexModel(RazorApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
			CategoryList = _db.Categories.ToList();
        }
    }
}
