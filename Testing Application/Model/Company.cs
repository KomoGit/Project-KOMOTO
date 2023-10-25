using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using TestingApplication.Model.Base;

namespace TestingApplication.Model
{
    public class Company:BaseEntity
    {
        [Required]
        [MaxLength(100,ErrorMessage = "Cannot exceed 100")]
        [BsonElement("companyName")]
        public string Name { get; set; }

        [Required]
        [MaxLength(300, ErrorMessage = "Cannot exceed 300")]
        [BsonElement("companyDescription")]
        public string Description { get; set; }

        [BsonElement("companyLogoLink")]
        public string CompanyLogoLink { get; set; }
    }
}