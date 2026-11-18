using MyPortfolioProject.Entities;

namespace MyPortfolioProject.Models
{
    public class DashboardViewModel
    {
        public int TotalProjects { get; set; }
        public int ActiveProjects { get; set; }
        public int TotalSkills { get; set; }
        public int TotalExperiences { get; set; }
        public int TotalEducations { get; set; }
        public int TotalMessages { get; set; }
        public int UnreadMessages { get; set; }
        public int ReadMessages { get; set; }

        public List<Message> LastMessages { get; set; } = new();
        public List<Project> LastProjects { get; set; } = new();
        public List<CategoryProjectCountItem> CategorySummary { get; set; } = new();
    }

    public class CategoryProjectCountItem
    {
        public string CategoryName { get; set; } = string.Empty;
        public int ProjectCount { get; set; }
    }
}

