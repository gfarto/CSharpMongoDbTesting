using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbTest.Models
{
    public class DocumentType
    {
        [BsonElement("id")]
        public int ID { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("period")]
        public int Period { get; set; }
    }
}
