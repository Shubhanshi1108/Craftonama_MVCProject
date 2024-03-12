using CraftonamaWebsite.Data;
using CraftonamaWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace CraftonamaWebsite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db= db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
		#region Create
		public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Create(Category categoryObj)
		{
            if (categoryObj.Name == categoryObj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display order cannot be same");
            }
            if (categoryObj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalid value");
            }
            if (ModelState.IsValid) 
            {
				_db.Categories.Add(categoryObj);
				_db.SaveChanges();
				TempData["success"] = "Category created successfully !";
				return RedirectToAction("Index");

			}
            return View();
		}
		#endregion

		#region Edit
		public IActionResult Edit(int? id)
		{
			if(id == null || id==0)
			{
				return NotFound();
			}
			/*Find can be used only for primary key*/
			Category? categoryFromDb= _db.Categories.Find(id);

			/*FirstOrDefault can be used with any field*/
			//Category? categoryFromDb2 = _db.Categories.FirstOrDefault(u => u.CategoryId == id);
			/*This is used when where clause is big when we need to apply many filters*/
			//Category? categoryFromDb3= _db.Categories.Where(u=>u.CategoryId == id).FirstOrDefault();

			if(categoryFromDb != null)
			{
				return View(categoryFromDb);

			}
			return NotFound();
		}

		[HttpPost]
		public IActionResult Edit(Category categoryObj)
		{
			
			if (ModelState.IsValid)
			{
				_db.Categories.Update(categoryObj);
				_db.SaveChanges();
				TempData["success"] = "Category updated successfully !";
				return RedirectToAction("Index");

			}
			return View();
		}

		#endregion

		#region Delete

		/*public IActionResult Delete(int? id)
		{
			if(id==null || id == 0)
			{
				return NotFound();
			}
			Category? obj= _db.Categories.Find(id);
			if(obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}*/

		//[HttpPost,ActionName("Delete")]
		public IActionResult Delete(int? id)
		{
			Category? obj = _db.Categories.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			_db.Categories.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "Category deleted successfully !";

			return RedirectToAction("Index");

		}

		#endregion
	}
}

