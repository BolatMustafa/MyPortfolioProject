using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.Context;

namespace MyPortfolioProject.ViewComponents
{
    public class _DefaultContactComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultContactComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SocialMedias = _context.SocialMedias.ToList();
            var contact = _context.Contacts.FirstOrDefault();
            return View(contact);
        }
    }
}

