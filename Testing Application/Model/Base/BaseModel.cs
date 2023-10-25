using System.ComponentModel.DataAnnotations;

namespace TestingApplication.Model
{
    [Obsolete]
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
