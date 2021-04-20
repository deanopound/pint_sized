using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PintSized.Api.Models
{
    public class ShortURLModel : MongoBaseModel
    {
        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("LongURL")]
        public string LongURL { get; set; }

        [BsonElement("ShortURL")]
        public string ShortURL { get; set; }
    }
}