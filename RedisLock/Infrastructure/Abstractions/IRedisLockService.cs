using StackExchange.Redis;

namespace RedisLock.Infrastructure.Abstractions;

public interface IRedisLockService
{
    Task<bool> TryAcquireLock(string key, string token, TimeSpan expiry);
    Task ReleaseLock(string key, string token);
}