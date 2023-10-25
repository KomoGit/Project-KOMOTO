using System.ComponentModel.DataAnnotations;
using TestingApplication.Model.Base;

namespace TestingApplication.Model
{
    public class Category:BaseModel
    {
        [Required]
        [MaxLength(60,ErrorMessage = "Cannot exceed 60")]
        public string Name { get; set; }
    }
}
