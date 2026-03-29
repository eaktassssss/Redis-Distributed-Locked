using MongoDB.Driver;
using RedisLock.Infrastructure.Persistence.Entities;

namespace RedisLock.Infrastructure.Persistence.Context;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
        _database = client.GetDatabase("SocialNetworkDb");
    }

    public IMongoCollection<MemberProfile> Members => 
        _database.GetCollection<MemberProfile>("MemberProfiles");

    public IMongoCollection<Follow> Follows => 
        _database.GetCollection<Follow>("Follows");
}