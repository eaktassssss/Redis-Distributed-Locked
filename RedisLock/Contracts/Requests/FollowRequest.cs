using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RedisLock.Contracts.Requests;

public class FollowRequest
{
    /// <summary>
    /// (Takip Eden)
    /// </summary>
    [BsonRepresentation(BsonType.Int32)]
    public int FollowerId { get; set; }

    /// <summary>
    /// (Takip Edilen)
    /// </summary>
    public int FollowingId { get; set; }
    
}