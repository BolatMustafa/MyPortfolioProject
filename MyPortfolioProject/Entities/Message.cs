using System.ComponentModel.DataAnnotations;

namespace MyPortfolioProject.Entities
{
    public class Message
    {
        public int MessageId { get; set; }

        [Required(ErrorMessage = "Ad Soyad alanı boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "Ad Soyad en fazla 100 karakter olabilir.")]
        public string SenderName { get; set; }

        [Required(ErrorMessage = "E-posta adresi boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [StringLength(150, ErrorMessage = "E-posta en fazla 150 karakter olabilir.")]
        public string SenderEmail { get; set; }

        [Required(ErrorMessage = "Konu alanı boş bırakılamaz.")]
        [StringLength(200, ErrorMessage = "Konu en fazla 200 karakter olabilir.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mesaj içeriği boş bırakılamaz.")]
        [StringLength(2000, ErrorMessage = "Mesaj en fazla 2000 karakter olabilir.")]
        public string MessageDetail { get; set; }

        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}

