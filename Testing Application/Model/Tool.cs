using System.ComponentModel.DataAnnotations;
using TestingApplication.Model.Base;

namespace TestingApplication.Model
{
    public class Tool:BaseModel
    {
        [Required]
        [MaxLength(100,ErrorMessage = "Cannot exceed 100 letters.")]
        public string Name { get; set; }
    }
}
