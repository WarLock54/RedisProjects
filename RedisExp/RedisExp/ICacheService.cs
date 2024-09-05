namespace RedisExp
{
    public interface ICacheService
    {
     /// Get Data using key
        T GetData<T>(string key);
        bool SetData<T>(string key, T value, DateTimeOffset expirationTime);
        object RemoveData(string key);
    }
}
