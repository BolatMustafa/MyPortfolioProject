using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class _DefaultProjectComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultProjectComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Projects
                .Include(x => x.Category)
                .Where(x => x.IsActive)
                .OrderByDescending(x => x.ProjectId)
                .ToList();

            ViewBag.Categories = _context.Categories.ToList();
            return View(values);
        }
    }
}
