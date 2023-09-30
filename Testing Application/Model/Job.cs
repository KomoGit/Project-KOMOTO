using System.ComponentModel.DataAnnotations;

namespace TestingApplication.Model
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}
