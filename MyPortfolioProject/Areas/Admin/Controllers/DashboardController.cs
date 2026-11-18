using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.Context;
using MyPortfolioProject.Models;

namespace MyPortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly PortfolioContext _context;

        public DashboardController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var projectCountsByCategory = _context.Projects
                .GroupBy(p => p.CategoryId)
                .Select(g => new { CategoryId = g.Key, Count = g.Count() })
                .ToList();

            var categories = _context.Categories.ToList();

            var model = new DashboardViewModel
            {
                TotalMessages = _context.Messages.Count(),
                UnreadMessages = _context.Messages.Count(x => !x.IsRead),
                ReadMessages = _context.Messages.Count(x => x.IsRead),
                TotalProjects = _context.Projects.Count(),
                ActiveProjects = _context.Projects.Count(x => x.IsActive),
                TotalSkills = _context.Skills.Count(),
                TotalExperiences = _context.Experiences.Count(),
                TotalEducations = _context.Educations.Count(),

                LastMessages = _context.Messages
                    .OrderByDescending(x => x.SendDate)
                    .Take(5)
                    .ToList(),

                LastProjects = _context.Projects
                    .Include(x => x.Category)
                    .OrderByDescending(x => x.ProjectId)
                    .Take(3)
                    .ToList(),

                CategorySummary = categories
                    .Select(c => new CategoryProjectCountItem
                    {
                        CategoryName = c.CategoryName,
                        ProjectCount = projectCountsByCategory.FirstOrDefault(x => x.CategoryId == c.CategoryId)?.Count ?? 0
                    })
                    .OrderByDescending(x => x.ProjectCount)
                    .ToList()
            };

            return View(model);
        }
    }
}
