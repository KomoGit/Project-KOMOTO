using System.ComponentModel.DataAnnotations;

namespace TestingApplication.Model
{
    public class Company:BaseModel
    {
        [Required]
        [MaxLength(100,ErrorMessage = "Cannot exceed 100")]
        public string Name { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage = "Cannot exceed 300")]
        public string Description { get; set; }
    }
}