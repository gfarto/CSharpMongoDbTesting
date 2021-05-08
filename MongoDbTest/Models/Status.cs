using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDbTest.Models
{
    public class Status
    {
        [BsonElement("id")]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("created_on")]
        public DateTime CreatedOn { get; set; }

        [BsonElement("notes")]
        public string Notes { get; set; }
    }
}
