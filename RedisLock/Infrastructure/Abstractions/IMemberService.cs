using MongoDB.Bson;
using RedisLock.Infrastructure.Persistence.Entities;

namespace RedisLock.Infrastructure.Abstractions;

public interface IMemberService
{
        Task<bool> IsAlreadyFollowing(int followingId,int followerId);
        Task CreateMemberAsync(MemberProfile memberProfile);
        Task<long> GetFollowingCountAsync(int followerId);
        Task<bool> IsAllowFollowing(int followingId);

}