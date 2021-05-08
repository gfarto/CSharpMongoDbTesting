using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbTest.Models
{
    public class Delivery
    {
        [BsonElement("id")]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string ID { get; set; }

        [BsonElement("document_key")]
        public string DocumentKey { get; set; }

        [BsonElement("customer_id")]
        public int CustomerID { get; set; }

        [BsonElement("created_on")]
        public DateTime CreatedOn { get; set; }

        [BsonElement("updated_on")]
        public DateTime UpdatedOn { get; set; }

        [BsonElement("movement_type_key")]
        public string MovementTypeKey { get; set; } = "Outbound";

        [BsonElement("ship_to")]
        public DeliveryPoint ShipTo { get; set; }

        [BsonElement("bill_to")]
        public DeliveryPoint BillTo { get; set; }

        [BsonElement("characteristics")]
        public List<Characteristic> Characteristics { get; set; }

        [BsonElement("status")]
        public List<Status> Status { get; set; }
    }
}
