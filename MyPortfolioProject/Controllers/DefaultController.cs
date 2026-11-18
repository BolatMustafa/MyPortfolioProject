using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.Context;
using MyPortfolioProject.Entities;

namespace MyPortfolioProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly PortfolioContext _context;

        public DefaultController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join(" ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                TempData["MessageError"] = errors;
                return Redirect("/Default/Index#contact");
            }

            message.SendDate = DateTime.Now;
            message.IsRead = false;
            _context.Messages.Add(message);
            _context.SaveChanges();
            TempData["MessageSent"] = "Mesajınız başarıyla gönderildi! En kısa sürede dönüş yapılacaktır.";
            return Redirect("/Default/Index#contact");
        }

    }
}

