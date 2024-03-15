using Craftonama.Models;
using Craftonama.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Craftonama.DataAccess.Repository.IRepository;

namespace CraftonamaWebsite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.categoryRepo.GetAll().ToList();
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
				_unitOfWork.categoryRepo.Add(categoryObj);
				_unitOfWork.Save();
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
			Category? categoryFromDb = _unitOfWork.categoryRepo.Get(u=>u.CategoryId==id);

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
				_unitOfWork.categoryRepo.Update(categoryObj);
				_unitOfWork.Save();
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
			Category? obj = _unitOfWork.categoryRepo.Get(u=>u.CategoryId==id);
			if (obj == null)
			{
				return NotFound();
			}
			_unitOfWork.categoryRepo.Remove(obj);
			_unitOfWork.Save();
			TempData["success"] = "Category deleted successfully !";

			return RedirectToAction("Index");

		}

		#endregion
	}
}

