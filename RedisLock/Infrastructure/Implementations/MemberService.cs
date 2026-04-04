using System.Collections.Immutable;
using MongoDB.Bson;
using MongoDB.Driver;
using RedisLock.Contracts.Requests;
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
    public async Task<bool> CreateAsync(MemberCreateRequest  memberCreateRequest)
    {
        try
        {
            MemberProfile memberProfile = new MemberProfile();
            memberProfile.MemberId = memberCreateRequest.MemberId;
            memberProfile.Name = memberCreateRequest.Name;
            memberProfile.IsAllowFollowing = memberCreateRequest.IsAllowFollowing;
            memberProfile.FollowerCount = memberCreateRequest.FollowerCount;
            memberProfile.FollowingCount = memberCreateRequest.FollowingCount;
            memberProfile.Username = memberCreateRequest.Username;
            await _context.Members.InsertOneAsync(memberProfile);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public Task<MemberProfile> GetAsync(int memberId)
    {
        var filter = Builders<MemberProfile>.Filter.Eq(m => m.MemberId, memberId);
        return _context.Members.Find(filter).FirstOrDefaultAsync();
    }

    public async Task IncrementFollowerCountAsync(int followerId, int following)
    {
        var followerTask = _context.Members.UpdateOneAsync(
            m => m.MemberId == followerId, 
            Builders<MemberProfile>.Update.Inc(m => m.FollowingCount, 1));

        var followedTask = _context.Members.UpdateOneAsync(
            m => m.MemberId == following, 
            Builders<MemberProfile>.Update.Inc(m => m.FollowerCount, 1));

        await Task.WhenAll(followerTask, followedTask);
    }
 
}