using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using TestingApplication.Enums;
using TestingApplication.Model.Base;

namespace TestingApplication.Model
{
    public class Job:BaseEntity
    {
        #region Basic Data
        [Required]
        [MaxLength(100,ErrorMessage = "Cannot exceed 100")]
        [BsonElement("jobTitle")]
        public string Title { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "Cannot exceed 150")]
        [BsonElement("jobDescription")]
        public string Description { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Cannot exceed 200")]
        [BsonElement("jobLink")]
        public string Link { get; set; }
        [BsonElement("jobEmployerId")]
        public string EmployerId { get; set; }
        public Company? Employer { get; set; }
        #endregion

        #region Detailed Data
        //How many people will be hired.
        public bool ShowNumberOfHires { get; set; } = false;
        public bool ShowNumberOfViews { get; set; } = true;
        public int NumberOfHires { get; set; } = 1;
        public int NumberOfViews { get; set; }
        [BsonElement("jobMaxSalary")]
        public float MaxSalary { get; set; } = 0;
        [BsonElement("jobMinSalary")]
        public float MinSalary { get; set; } = 0;
        public bool DeterminedAtInterview { get; set; } = false;
        [BsonElement("jobEmploymentType")]
        public EmploymentType EmploymentType { get; set; } = EmploymentType.FULLTIME;
        [BsonElement("jobLocationType")]
        public LocationType LocationType { get; set; } = LocationType.OFFICE;
        [BsonElement("jobSeniorityLevel")]
        public JobLevels SeniorityLevel { get; set; } = JobLevels.Junior;
        #endregion

        #region Requirments
        public int MinimumExperienceInYears { get; set; } = 0;
        public int MinimumAgeRequirement { get; set; } = 18;
        public int MaximumAgeRequirement { get; set; } = 64;
        public bool WomenNeedNotApply { get; set; } = false;
        public bool MenNeedNotApply { get; set; } = false;
        //Tools
        //Must have, if they do know these tools, they are excluded immediately.
        [Required]
        public string RequiredTools { get; set; }
        //Optional, whether the applicants know it or not doesn't matter much.
        public string? AdditionalTools { get; set; }

        //Languages
        //Many-To-Many?

        //Certifiactes
        [Required]
        public string RequiredCertificates { get; set; } //Same as Tools
        public string? AdditionalCertificates { get; set; }
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
