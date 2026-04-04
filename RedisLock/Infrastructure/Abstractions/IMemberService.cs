using MongoDB.Bson;
using RedisLock.Contracts.Requests;
using RedisLock.Infrastructure.Persistence.Entities;

namespace RedisLock.Infrastructure.Abstractions;

public interface IMemberService
{
        Task<bool> CreateAsync(MemberCreateRequest   memberCreateRequest);
        Task<MemberProfile> GetAsync(int memberId);
        Task IncrementFollowerCountAsync(int followerId, int following);
}