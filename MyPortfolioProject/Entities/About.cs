namespace MyPortfolioProject.Entities
{
    public class About
    {
        public int AboutId { get; set; }
        public string ImageUrl { get; set; }
        public string FullNameLocation { get; set; } // Örn: Mustafa Bolat, Corum
        public string Title { get; set; }            // Örn: Junior Developer
        public string Heading { get; set; }          // Örn: Teknolojiye Tutkuyla Bağlı Bir Yolculuk.
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Stat1Number { get; set; }      // Örn: 10+
        public string Stat1Title { get; set; }       // Örn: Yıl Deneyim
        public string Stat2Number { get; set; }      // Örn: 25+
        public string Stat2Title { get; set; }       // Örn: Eğitim İçeriği
        public string Stat3Number { get; set; }      // Örn: 200K+
        public string Stat3Title { get; set; }       // Örn: Öğrenci
        public string CvUrl { get; set; }
    }
}
