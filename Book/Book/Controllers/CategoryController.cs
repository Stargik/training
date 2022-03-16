using Microsoft.AspNetCore.Mvc;
using Book.Data;
using Book.Models;

namespace Book.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationContext dbCotext;

        public CategoryController(ApplicationContext applicationContext)
        {
            dbCotext = applicationContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = dbCotext.Categories;    
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot have the same value with Name.");
            }
            if (ModelState.IsValid)
            {
                dbCotext.Categories.Add(category);
                dbCotext.SaveChanges();
                TempData["success"] = "Category created successfuiiy";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var category = dbCotext.Categories.FirstOrDefault(c => c.Id == id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot have the same value with Name.");
            }
            if (ModelState.IsValid)
            {
                dbCotext.Categories.Update(category);
                dbCotext.SaveChanges();
                TempData["success"] = "Category updated successfuiiy";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = dbCotext.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var category = dbCotext.Categories.FirstOrDefault(c => c.Id == id);
            if(category == null)
            {
                return NotFound();
            }
            dbCotext.Categories.Remove(category);
            dbCotext.SaveChanges();
            TempData["success"] = "Category deleted successfuiiy";
            return RedirectToAction("Index");

        }
    }
}
