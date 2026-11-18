using Microsoft.EntityFrameworkCore;
using MyPortfolioProject.Entities;

namespace MyPortfolioProject.Context
{
    public class PortfolioContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MB\\SQLEXPRESS;Initial Catalog=FirstPortfolioProjectDb;Integrated Security=True;TrustServerCertificate=True");

        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<HeroSection> HeroSections { get; set; }
        public DbSet<HeroTitle> HeroTitles { get; set; }
        public DbSet<SkillItem> SkillItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
    }
}
