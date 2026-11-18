using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPortfolioProject.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Proje adı boş bırakılamaz.")]
        [StringLength(150, ErrorMessage = "Proje adı en fazla 150 karakter olabilir.")]
        public string ProjectTitle { get; set; }

        [Required(ErrorMessage = "Proje açıklaması boş bırakılamaz.")]
        [StringLength(1000, ErrorMessage = "Proje açıklaması en fazla 1000 karakter olabilir.")]
        public string Description { get; set; }

        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [Required(ErrorMessage = "Kullanılan teknolojiler boş bırakılamaz.")]
        [StringLength(250, ErrorMessage = "Teknolojiler alanı en fazla 250 karakter olabilir.")]
        public string Technologies { get; set; }

        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Kategori seçimi zorunludur.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
