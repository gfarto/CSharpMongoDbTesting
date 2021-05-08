using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbTest.Models
{
    public class Characteristic
    {
        [BsonElement("id")]
        public int Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("value")]
        public string Value { get; set; }
    }
}
