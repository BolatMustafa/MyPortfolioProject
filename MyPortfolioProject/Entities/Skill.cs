using System.ComponentModel.DataAnnotations;

namespace MyPortfolioProject.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }

        [Required(ErrorMessage = "Başlık alanı boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama alanı boş bırakılamaz.")]
        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "İkon bilgisi boş bırakılamaz.")]
        public string IconUrl { get; set; }

        public List<SkillItem> SkillItems { get; set; }
    }
}
