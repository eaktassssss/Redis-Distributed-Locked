using RedisLock.Infrastructure.Abstractions;
using RedisLock.Infrastructure.Persistence.Context;
using RedisLock.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRedisLockService, RedisLockService>();
builder.Services.AddSingleton<IFollowService, FollowService>();
builder.Services.AddSingleton<IMemberService, MemberService>();
builder.Services.AddSingleton<MongoDbContext>();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();