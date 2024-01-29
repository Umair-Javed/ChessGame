using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using WebFront.Enums;

namespace WebFront.MongoDbEntities
{
    public class UserDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public PlayerType Type { get; set; }
        public string UserName { get; set; }
        public string GroupId { get; set; }
        public string ConnectionId { get; set; }
        public bool IsOnline { get; set; }
        public bool IsPlaying { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
