using System.ComponentModel.DataAnnotations;

namespace TestingApplication.Model
{
    public class Job:BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public Category JobCategory { get; set; }
    }
}
