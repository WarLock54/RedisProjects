using StackExchange.Redis;

namespace RedisWithTool
{
    public interface IRedisDbProvider : IDisposable
    {
        public IDatabase database { get; }
    }
}
