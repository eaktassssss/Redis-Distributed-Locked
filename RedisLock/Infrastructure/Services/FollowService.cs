using RedisLock.Infrastructure.Abstractions;
using RedisLock.Infrastructure.Persistence.Entities;

namespace RedisLock.Infrastructure.Services;

public class FollowService:IFollowService
{
    public Task<bool> CreateFollow(Follow follow)
    {
        return default;
    }
}