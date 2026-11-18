using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.Context;
using MyPortfolioProject.Entities;

namespace MyPortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HeroSectionController : Controller
    {
        private readonly PortfolioContext _context;

        public HeroSectionController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var value = _context.HeroSections.FirstOrDefault();
            if (value == null)
            {
                value = new HeroSection
                {
                    Greeting = "MERHABA BEN MUSTAFA",
                    Title = "Elektrik Elektronik Mühendisi",
                    Description = "Kısa tanıtım yazısı...",
                    MainImageUrl = "/images/hero.jpg"
                };
                _context.HeroSections.Add(value);
                _context.SaveChanges();
            }
            return View(value);
        }

        [HttpPost]
        public IActionResult Index(HeroSection heroSection)
        {
            _context.HeroSections.Update(heroSection);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
