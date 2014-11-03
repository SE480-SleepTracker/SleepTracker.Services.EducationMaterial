using System.ComponentModel.DataAnnotations;

namespace SleepTracker.Services.Education.Models
{
    public class EducationArticle
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }
}