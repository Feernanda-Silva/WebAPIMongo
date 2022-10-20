using MongoDB.Bson.Serialization.Attributes;

namespace WebAPIMongo.Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Street { get; set; }
    }
}
