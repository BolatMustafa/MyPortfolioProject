using System.Net.Http.Headers;

namespace MyPortfolioProject.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Project> Projects { get; set; }
    }
}
