using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.Context;
using MyPortfolioProject.Entities;

namespace MyPortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly PortfolioContext _context;
        private readonly IWebHostEnvironment _env;

        public ProjectController(PortfolioContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult ProjectList(int? categoryId, string sortOrder = "newest")
        {
            // Filtreleme dropdown'ı için kategorileri gönder
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName", categoryId);
            ViewBag.SelectedCategoryId = categoryId;
            ViewBag.CurrentSort = sortOrder;

            var query = _context.Projects
                .Include(x => x.Category)
                .AsQueryable();

            // 1. Kategori Filtreleme
            if (categoryId.HasValue && categoryId.Value > 0)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }

            // 2. Anlamlı Sıralama (Varsayılan: En Yeni Proje)
            query = sortOrder switch
            {
                "oldest" => query.OrderBy(x => x.ProjectId),
                "title_asc" => query.OrderBy(x => x.ProjectTitle),
                "title_desc" => query.OrderByDescending(x => x.ProjectTitle),
                _ => query.OrderByDescending(x => x.ProjectId) // newest (En Yeni Proje)
            };

            var values = query.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(Project project)
        {
            ModelState.Remove("Category");

            if (project.ImageFile == null || project.ImageFile.Length == 0)
            {
                ModelState.AddModelError("ImageFile", "Lütfen bir proje görseli seçiniz.");
            }
            else
            {
                var uploadResult = await SaveImageAsync(project.ImageFile);
                if (!uploadResult.Success)
                {
                    ModelState.AddModelError("ImageFile", uploadResult.ErrorMessage!);
                }
                else
                {
                    project.ImageUrl = uploadResult.FilePath;
                }
            }

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Lütfen zorunlu alanları ve görsel formatını kontrol ediniz.";
                ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
                return View(project);
            }

            try
            {
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Yeni proje başarıyla eklendi.";
                return RedirectToAction("ProjectList");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Proje eklenirken beklenmeyen bir hata oluştu.";
                ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
                return View(project);
            }
        }

        [HttpGet]
        public IActionResult UpdateProject(int id)
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
            var value = _context.Projects.Find(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProject(Project project)
        {
            ModelState.Remove("Category");

            if (project.ImageFile != null && project.ImageFile.Length > 0)
            {
                var uploadResult = await SaveImageAsync(project.ImageFile);
                if (!uploadResult.Success)
                {
                    ModelState.AddModelError("ImageFile", uploadResult.ErrorMessage!);
                }
                else
                {
                    project.ImageUrl = uploadResult.FilePath;
                }
            }

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Lütfen girdiğiniz bilgileri ve görseli kontrol ediniz.";
                ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
                return View(project);
            }

            try
            {
                _context.Projects.Update(project);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Proje bilgileri başarıyla güncellendi.";
                return RedirectToAction("ProjectList");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Proje güncellenirken beklenmeyen bir hata oluştu.";
                ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
                return View(project);
            }
        }

        public IActionResult DeleteProject(int id)
        {
            var value = _context.Projects.Find(id);
            if (value == null)
            {
                TempData["ErrorMessage"] = "Silinmek istenen proje bulunamadı.";
                return RedirectToAction("ProjectList");
            }

            try
            {
                _context.Projects.Remove(value);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Proje başarıyla silindi.";
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Proje silinirken bir hata oluştu.";
            }

            return RedirectToAction("ProjectList");
        }

        private async Task<(bool Success, string? FilePath, string? ErrorMessage)> SaveImageAsync(IFormFile file)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
            {
                return (false, null, "Sadece .jpg, .jpeg, .png veya .webp formatında görsel yükleyebilirsiniz.");
            }

            const long maxFileSize = 2 * 1024 * 1024; // 2 MB
            if (file.Length > maxFileSize)
            {
                return (false, null, "Görsel boyutu en fazla 2 MB olabilir.");
            }

            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads", "projects");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var safeFileName = $"{Guid.NewGuid()}{extension}";
            var fullPath = Path.Combine(uploadsFolder, safeFileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return (true, $"/uploads/projects/{safeFileName}", null);
        }
    }
}
