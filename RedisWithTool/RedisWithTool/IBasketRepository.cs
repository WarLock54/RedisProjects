namespace RedisWithTool
{
    public interface IBasketRepository
    {
        Task<UserBasket> GetBasketAsync(string basketId);
        Task<UserBasket> UpdateBasketAsync(UserBasket basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
