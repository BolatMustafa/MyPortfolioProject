using Microsoft.AspNetCore.Mvc;
using MyPortfolioProject.Context;
using MyPortfolioProject.Entities;

namespace MyPortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly PortfolioContext _context;

        public MessageController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult MessageList(string search)
        {
            var query = _context.Messages.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.SenderName.Contains(search) || x.Subject.Contains(search));
                ViewBag.Search = search;
            }

            var values = query.OrderByDescending(x => x.SendDate).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult GetMessageDetail(int id)
        {
            var message = _context.Messages.Find(id);
            if (message == null) return NotFound();

            if (!message.IsRead)
            {
                message.IsRead = true;
                _context.SaveChanges();
            }

            int unreadCount = _context.Messages.Count(x => !x.IsRead);

            return Json(new
            {
                messageId = message.MessageId,
                senderName = message.SenderName,
                senderEmail = message.SenderEmail,
                subject = message.Subject,
                messageDetail = message.MessageDetail,
                sendDate = message.SendDate.ToString("dd.MM.yyyy HH:mm"),
                unreadCount = unreadCount
            });
        }

        public IActionResult ChangeReadStatus(int id)
        {
            var message = _context.Messages.Find(id);
            if (message != null)
            {
                message.IsRead = !message.IsRead;
                _context.SaveChanges();
                TempData["SuccessMessage"] = message.IsRead
                    ? "Mesaj 'Okundu' olarak işaretlendi."
                    : "Mesaj 'Okunmadı' olarak işaretlendi.";
            }
            return RedirectToAction("MessageList");
        }

        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            if (value == null)
            {
                TempData["ErrorMessage"] = "Silinmek istenen mesaj bulunamadı.";
                return RedirectToAction("MessageList");
            }

            try
            {
                _context.Messages.Remove(value);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Mesaj başarıyla silindi.";
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Mesaj silinirken beklenmeyen bir hata oluştu.";
            }

            return RedirectToAction("MessageList");
        }
    }
}


