using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RedisLock.Infrastructure.Persistence.Entities;

public class Follow
{
    public ObjectId Id { get; set; }
    public bool IsActive { get; set; }
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }
    public DateTime CreatedAt { get; set; } 
}