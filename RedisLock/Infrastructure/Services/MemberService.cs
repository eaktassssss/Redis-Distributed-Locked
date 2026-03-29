using MongoDB.Bson;
using MongoDB.Driver;
using RedisLock.Infrastructure.Abstractions;
using RedisLock.Infrastructure.Persistence.Context;
using RedisLock.Infrastructure.Persistence.Entities;

namespace RedisLock.Infrastructure.Services;

public class MemberService:IMemberService
{
    private readonly MongoDbContext _context;

    public MemberService(MongoDbContext context)
    {
        _context = context;
    }

    public Task<bool> IsAlreadyFollowing(int followingId, int followerId)
    {
        //  zaten takip ediyor mu
        throw new NotImplementedException();
    }

    public async Task CreateMemberAsync(MemberProfile memberProfile)
    {
        await _context.Members.InsertOneAsync(memberProfile);
    }

    public Task<long> GetFollowingCountAsync(int followerId)
    {
        // takip etmek isteyen kişi max takip etme limitine ulaştı mı örneğin  limit 100
        throw new NotImplementedException();
    }

    public Task<bool> IsAllowFollowing(int followingId)
    {
        // takip edilmek istenen kişinin bu ayarı açık mı ?
        throw new NotImplementedException();
    }
}