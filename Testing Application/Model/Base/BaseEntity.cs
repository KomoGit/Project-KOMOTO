using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TestingApplication.Services;

namespace TestingApplication.Model.Base
{
    public class BaseEntity : IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}