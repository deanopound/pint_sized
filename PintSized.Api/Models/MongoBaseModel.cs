using MongoDB.Bson;

namespace PintSized.Api.Models
{
    public abstract class MongoBaseModel
    {
        public ObjectId Id { get; set; }
    }
}