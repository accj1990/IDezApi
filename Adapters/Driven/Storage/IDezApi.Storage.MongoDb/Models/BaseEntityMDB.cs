using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IDezApi.Storage.MongoDb.Models
{
    public class BaseEntityMDB
    {
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    }
}
