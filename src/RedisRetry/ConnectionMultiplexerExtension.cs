using StackExchange.Redis;

namespace RedisRetry
{
    public static class IConnectionMultiplexerExtension
    {
        public static IRedisRetryDatabase GetRetryDatabase(this IConnectionMultiplexer multiplexer, int db = -1, object asyncState = null)
        {
            return new RedisRetryDatabase(multiplexer.GetDatabase(db, asyncState));
        }
    }
}
