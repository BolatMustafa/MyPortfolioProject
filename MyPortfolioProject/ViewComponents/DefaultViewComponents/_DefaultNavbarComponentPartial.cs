using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();

        }
    }
}
