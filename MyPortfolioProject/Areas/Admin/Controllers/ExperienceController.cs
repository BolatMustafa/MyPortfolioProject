using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.Context;
using MyPortfolioProject.Entities;

namespace MyPortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperienceController : Controller
    {
        private readonly PortfolioContext _context;

        public ExperienceController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult ExperienceList()
        {
            var values = _context.Experiences.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Lütfen tüm zorunlu deneyim bilgilerini eksiksiz doldurunuz.";
                return View(experience);
            }

            try
            {
                _context.Experiences.Add(experience);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Yeni deneyim kaydı başarıyla eklendi.";
                return RedirectToAction("ExperienceList");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Deneyim eklenirken beklenmeyen bir hata oluştu.";
                return View(experience);
            }
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var value = _context.Experiences.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Lütfen deneyim bilgilerini kontrol edip tekrar deneyiniz.";
                return View(experience);
            }

            try
            {
                _context.Experiences.Update(experience);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Deneyim bilgileri başarıyla güncellendi.";
                return RedirectToAction("ExperienceList");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Deneyim güncellenirken beklenmeyen bir hata oluştu.";
                return View(experience);
            }
        }

        public IActionResult DeleteExperience(int id)
        {
            var value = _context.Experiences.Find(id);
            if (value == null)
            {
                TempData["ErrorMessage"] = "Silinmek istenen deneyim kaydı bulunamadı.";
                return RedirectToAction("ExperienceList");
            }

            try
            {
                _context.Experiences.Remove(value);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Deneyim kaydı başarıyla silindi.";
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Deneyim silinirken bir hata oluştu.";
            }

            return RedirectToAction("ExperienceList");
        }
    }
}

