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
        [Required]
        public Category? JobCategory { get; set; }
        public bool IsArchived { get; set; }
        #endregion

        #region Detailed Data
        //How many people will be hired.
        public bool ShowNumberOfHires { get; set; }
        public bool ShowNumberOfViews { get; set; }
        public int NumberOfHires { get; set; }
        public int NumberOfViews { get; set; }
        [BsonElement("jobMaxSalary")]
        public float MaxSalary { get; set; }
        [BsonElement("jobMinSalary")]
        public float MinSalary { get; set; }
        public bool DeterminedAtInterview { get; set; }
        [BsonElement("jobEmploymentType")]
        public EmploymentType EmploymentType { get; set; }
        [BsonElement("jobLocationType")]
        public LocationType LocationType { get; set; }
        [BsonElement("jobSeniorityLevel")]
        public JobLevels JobLevels { get; set; }
        #endregion

        #region Requirments
        public int MinimumExperienceInYears { get; set; }
        public int MinimumAgeRequirement { get; set; }
        public int MaximumAgeRequirement { get; set; }
        public bool WomenNeedNotApply { get; set; }
        public bool MenNeedNotApply { get; set; }
        //Tools
        //Must have, if they do know these tools, they are excluded immediately.
        public string? RequiredTools { get; set; }
        //Optional, whether the applicants know it or not doesn't matter much.
        public string? AdditionalTools { get; set; }

        //Languages
        //Many-To-Many?

        //Certifiactes
        public string? RequiredCertificates { get; set; }
        public string? AdditionalCertificates { get; set; }
        #endregion

        #region Dates
        public DateTime PublishDate { get; set; }
        public DateTime ExpirationDate { get; set; } 
        #endregion
    }
}
