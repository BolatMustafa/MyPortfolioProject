using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultStyleComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
 