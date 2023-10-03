using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingApplication.Model
{
    public class Company:BaseModel
    {
        [Required]
        [MaxLength(100,ErrorMessage = "Cannot exceed 100")]
        public string Name { get; set; }
        [NotMapped]
        public List<Job>? ActiveJobs { get; set; }
    }
}