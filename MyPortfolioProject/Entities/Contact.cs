using System.ComponentModel.DataAnnotations;

namespace MyPortfolioProject.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Başlık boş bırakılamaz.")]
        [StringLength(150, ErrorMessage = "Başlık en fazla 150 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "E-posta adresi boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon numarası boş bırakılamaz.")]
        [StringLength(30, ErrorMessage = "Telefon numarası en fazla 30 karakter olabilir.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Konum bilgisi boş bırakılamaz.")]
        [StringLength(150, ErrorMessage = "Konum bilgisi en fazla 150 karakter olabilir.")]
        public string Location { get; set; }
    }
}
