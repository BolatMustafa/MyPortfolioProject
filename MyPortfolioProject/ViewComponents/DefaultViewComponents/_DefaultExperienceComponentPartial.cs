using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.Context;

namespace MyPortfolioProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultExperienceComponentPartial:ViewComponent
    {
        private readonly PortfolioContext _context;
public _DefaultExperienceComponentPartial(PortfolioContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Experiences.ToList();
            return View(values);
        }
    }
}
