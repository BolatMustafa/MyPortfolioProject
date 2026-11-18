using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.Context;
using MyPortfolioProject.Entities;

namespace MyPortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly PortfolioContext _context;

        public AboutController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var value = _context.Abouts.FirstOrDefault();
            if (value == null)
            {
                value = new About
                {
                    ImageUrl = "https://placeholder.com",
                    FullNameLocation = "Mustafa Bolat, İstanbul",
                    Title = "Senior Developer",
                    Heading = "Teknolojiye Tutkuyla Bağlı Bir Yolculuk.",
                    Description1 = "Merhaba, ben Mustafa Bolat...",
                    Description2 = "Teknolojinin yalnızca kod yazmaktan ibaret olmadığına...",
                    Stat1Number = "10+",
                    Stat1Title = "Yıl Deneyim",
                    Stat2Number = "25+",
                    Stat2Title = "Eğitim İçeriği",
                    Stat3Number = "200K+",
                    Stat3Title = "Öğrenci",
                    CvUrl = "#"
                };
                _context.Abouts.Add(value);
                _context.SaveChanges();
            }
            return View(value);
        }

        [HttpPost]
        public IActionResult Index(About about)
        {
            _context.Abouts.Update(about);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

