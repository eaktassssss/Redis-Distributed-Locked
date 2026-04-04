using RedisLock.Contracts.Requests;
using RedisLock.Contracts.Responses;
using RedisLock.Infrastructure.Persistence.Entities;

namespace RedisLock.Infrastructure.Abstractions;

public interface IFollowService
{
    Task<ServiceResponse> CreateFollow(int followerId, int followingId);
    Task<bool> IsAlreadyFollowingAsync(int followerId, int followingId);
}