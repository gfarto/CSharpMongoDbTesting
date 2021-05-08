using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbTest.Models
{
    public class DeliveryPoint
    {
        [BsonElement("id")]
        public int Id { get; set; }

        [BsonElement("code")]
        public string Code { get; set; }

        [BsonElement("main_street")]
        public string MainStreet { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("state")]
        public string State { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }

    }
}
