using Microsoft.EntityFrameworkCore;
using RedisWithTool;
using RedisWithTool.Models;
using ServiceStack.Redis;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();

// redis connection config 
builder.Services.AddSingleton<LocationService>();
builder.Services.AddSingleton<IConnectionMultiplexer>(opt =>
{
    var redisUrl = builder.Configuration.GetConnectionString("Redis");
    return ConnectionMultiplexer.Connect(redisUrl);
});
builder.Services.AddSingleton<IRedisClientsManager>(c =>
      new RedisManagerPool("localhost:6379"));

builder.Services.AddDbContext<StoreContext>(options =>
{

    options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
