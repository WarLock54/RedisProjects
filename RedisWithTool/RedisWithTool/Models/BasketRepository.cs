using StackExchange.Redis;
using System.Text.Json;

namespace RedisWithTool.Models
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _redisDb;

        public BasketRepository(IConnectionMultiplexer redis)
        {
            _redisDb = redis.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _redisDb.KeyDeleteAsync(basketId);
        }

        public async Task<UserBasket?> GetBasketAsync(string basketId)
        {
            var basket = await _redisDb.StringGetAsync(basketId);
            return basket.IsNull ? null : JsonSerializer.Deserialize<UserBasket>(basket);
        }

        public async Task<UserBasket?> UpdateBasketAsync(UserBasket basket)
        {
            // yoksa yenisini oluşturur
            // son parametre basket
            var updateOrCreateBasket = await _redisDb.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
            if (updateOrCreateBasket)
                return await GetBasketAsync(basket.Id);
            return null;
        }
    }
}
