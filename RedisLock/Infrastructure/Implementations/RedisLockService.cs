using RedisLock.Infrastructure.Abstractions;
using StackExchange.Redis;

namespace RedisLock.Infrastructure.Services;

public class RedisLockService : IRedisLockService
{
    private readonly IDatabase _db;
    public RedisLockService(IConnectionMultiplexer connectionMultiplexer)
    {
        _db = connectionMultiplexer.GetDatabase();
    }
    public async Task<bool> TryAcquireLock(string key, string token, TimeSpan expiry)
    {
        return await _db.StringSetAsync(key, token, expiry, When.NotExists);
    }
    public async Task ReleaseLock(string key, string token)
    {
        string luaScript = @"
            if redis.call('get', KEYS[1]) == ARGV[1] then
                return redis.call('del', KEYS[1])
            else
                return 0
            end";
        await _db.ScriptEvaluateAsync(luaScript, new RedisKey[] { key }, new RedisValue[] { token });
    }
}