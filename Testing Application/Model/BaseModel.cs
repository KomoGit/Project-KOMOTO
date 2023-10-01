using System.ComponentModel.DataAnnotations;

namespace TestingApplication.Model
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
