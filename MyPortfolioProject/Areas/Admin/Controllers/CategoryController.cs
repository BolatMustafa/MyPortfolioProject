using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.Context;
using MyPortfolioProject.Entities;

namespace MyPortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly PortfolioContext _context;

        public CategoryController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                TempData["ErrorMessage"] = "Kategori adı boş bırakılamaz!";
                return View(category);
            }

            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Yeni kategori başarıyla eklendi.";
                return RedirectToAction("CategoryList");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Kategori eklenirken beklenmeyen bir hata oluştu.";
                return View(category);
            }
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = _context.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                TempData["ErrorMessage"] = "Kategori adı boş bırakılamaz!";
                return View(category);
            }

            try
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Kategori bilgileri başarıyla güncellendi.";
                return RedirectToAction("CategoryList");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Kategori güncellenirken bir hata oluştu.";
                return View(category);
            }
        }

        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            if (value == null)
            {
                TempData["ErrorMessage"] = "Silinmek istenen kategori bulunamadı.";
                return RedirectToAction("CategoryList");
            }

            try
            {
                _context.Categories.Remove(value);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Kategori başarıyla silindi.";
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Bu kategoriye bağlı projeler olduğu için silinemiyor.";
            }

            return RedirectToAction("CategoryList");
        }
    }
}
