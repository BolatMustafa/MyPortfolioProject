using System.ComponentModel.DataAnnotations;

namespace MyPortfolioProject.Entities
{
    public class SkillItem
    {
        public int SkillItemId { get; set; }

        [Required(ErrorMessage = "Yetenek adı boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "Yetenek adı en fazla 100 karakter olabilir.")]
        public string SkillItemTitle { get; set; }

        [Required(ErrorMessage = "Seviye oranı boş bırakılamaz.")]
        [Range(0, 100, ErrorMessage = "Seviye oranı 0 ile 100 arasında olmalıdır.")]
        public int Rate { get; set; }

        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
