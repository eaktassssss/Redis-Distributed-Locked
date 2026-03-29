using RedisLock.Infrastructure.Persistence.Entities;

namespace RedisLock.Infrastructure.Abstractions;

public interface IFollowService
{
    Task<bool> CreateFollow(Follow follow);
}