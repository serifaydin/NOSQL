using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CA_MongoDB
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("quantity")]
        public int Quantity { get; set; }

        [BsonElement("status")]
        public bool Status { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

        [BsonElement("categoryid")]
        public int CategoryId { get; set; }

        [BsonElement("IsActive")]
        public bool isActive { get; set; }
    }
}