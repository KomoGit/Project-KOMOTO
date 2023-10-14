using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using TestingApplication.Enums;
using TestingApplication.Model;

namespace TestingApplication.Data_Transfer_Objects
{
    public class JobDTO
    {
        public int Id { get; set; }
        #region Basic Data
        [Required]
        [MaxLength(100, ErrorMessage = "Cannot exceed 100")]
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

        #region Detailed Data
        //How many people will be hired.
        public int NumberOfHires { get; set; } = 1;
        public int NumberOfViews { get; set; }
        public EmploymentType EmploymentType { get; set; } = EmploymentType.FULLTIME;
        public LocationType LocationType { get; set; } = LocationType.OFFICE;
        #endregion

        #region Requirments
        public int MinimumExperienceInYears { get; set; } = 0;
        public int MinimumAgeRequirement { get; set; } = 18;
        public int MaximumAgeRequirement { get; set; } = 64;
        public bool WomenNeedNotApply { get; set; } = false;
        public bool MenNeedNotApply { get; set; } = false;
        //Tools
        //Languages
        //Certifiactes
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
