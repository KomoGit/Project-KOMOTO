using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TestingApplication.Model
{
    public class Job:BaseModel
    {
        #region Basic Data
        [Required]
        [MaxLength(100,ErrorMessage = "Cannot exceed 100")]
        public string Title { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "Cannot exceed 150")]
        public string Description { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Cannot exceed 200")]
        public string Link { get; set; }
        public int EmployerId { get; set; }
        public Company? Employer { get; set; }
        #endregion
        #region Metadata
        [Required]
        public int CategoryId { get; set; }
        public Category? JobCategory { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; } = DateTime.Now.AddDays(1);
        public DateTime PublishDate { get; set; } = DateTime.Now;
        #endregion
    }
}
