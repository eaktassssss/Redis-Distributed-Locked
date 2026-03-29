using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RedisLock.Infrastructure.Persistence.Entities;

public class MemberProfile
{
    public ObjectId Id { get; set; }
    public int MemberId { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public bool IsAllowFollowing { get; set; }
    public int TotalFollowingCount { get; set; }
}