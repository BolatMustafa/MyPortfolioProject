using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.Context;
using MyPortfolioProject.Entities;

namespace MyPortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillItemController : Controller
    {
        private readonly PortfolioContext _context;

        public SkillItemController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult SkillItemList()
        {
            var values = _context.SkillItems.Include(x => x.Skill).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSkillItem()
        {
            ViewBag.Skills = new SelectList(_context.Skills.ToList(), "SkillId", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkillItem(SkillItem skillItem)
        {
            _context.SkillItems.Add(skillItem);
            _context.SaveChanges();
            return RedirectToAction("SkillItemList");
        }

        [HttpGet]
        public IActionResult UpdateSkillItem(int id)
        {
            ViewBag.Skills = new SelectList(_context.Skills.ToList(), "SkillId", "Title");
            var value = _context.SkillItems.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSkillItem(SkillItem skillItem)
        {
            _context.SkillItems.Update(skillItem);
            _context.SaveChanges();
            return RedirectToAction("SkillItemList");
        }

        public IActionResult DeleteSkillItem(int id)
        {
            var value = _context.SkillItems.Find(id);
            _context.SkillItems.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("SkillItemList");
        }
    }
}
