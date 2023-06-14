using Bogus.Bson;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace APIMongodbs.Models
{
    public class Cliente
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Category { get; set; }
        public DateTime Fecha { get; set; }

    }
}
