using System;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace RedisRetry
{
    public static class RedisConnectionExtensions
    {
        public static Task<bool> HashSetAsyncWithRetries(this IDatabase database, RedisKey key, RedisValue hashField, RedisValue value)
        {
            return new RetryTask<bool>(() => database.HashSetAsync(key, hashField, value)).RunAsync();
        }

        public static Task<long> HashIncrementAsyncWithRetries(this IDatabaseAsync database, RedisKey key, RedisValue hashField, long value, CommandFlags flags = CommandFlags.None)
        {
            return new RetryTask<long>(() => database.HashIncrementAsync(key, hashField, value, flags)).RunAsync();
        }

        public static Task<bool> HyperLogLogAddAsyncWithRetries(this IDatabase database, RedisKey key, RedisValue value, CommandFlags flags = CommandFlags.None)
        {
            return new RetryTask<bool>(() => database.HyperLogLogAddAsync(key, value, flags)).RunAsync();
        }

        public static Task<long> HyperLogLogLengthAsyncWithRetries(this IDatabase database, RedisKey key)
        {
            return new RetryTask<long>(() => database.HyperLogLogLengthAsync(key)).RunAsync();
        }

        public static Task<RedisValue> HashGetAsyncWithRetries(this IDatabase database, RedisKey key, RedisValue hashField)
        {
            return new RetryTask<RedisValue>(() => database.HashGetAsync(key, hashField)).RunAsync();
        }

        public static Task<RedisValue> HashGetAsyncWithRetries(this IDatabaseAsync database, RedisKey key, RedisValue hashField)
        {
            return new RetryTask<RedisValue>(() => database.HashGetAsync(key, hashField)).RunAsync();
        }

        public static Task<RedisValue[]> HashGetAsyncWithRetries(this IDatabaseAsync database, RedisKey key, RedisValue[] hashFields)
        {
            return new RetryTask<RedisValue[]>(() => database.HashGetAsync(key, hashFields)).RunAsync();
        }

        public static Task<HashEntry[]> HashGetAllAsyncWithRetries(this IDatabase database, RedisKey key)
        {
            return new RetryTask<HashEntry[]>(() => database.HashGetAllAsync(key)).RunAsync();
        }

        public static Task<bool> KeyDeleteAsyncWithRetries(this IDatabase database, RedisKey key)
        {
            return new RetryTask<bool>(() => database.KeyDeleteAsync(key)).RunAsync();
        }

        public static Task<bool> KeyExpireAsyncWithRetries(this IDatabase database, RedisKey key, TimeSpan timespan)
        {
            return new RetryTask<bool>(() => database.KeyExpireAsync(key, timespan)).RunAsync();
        }

        public static Task<double> SortedSetIncrementAsyncWithRetries(this IDatabase database, RedisKey key, RedisValue member, double value)
        {
            return new RetryTask<double>(() => database.SortedSetIncrementAsync(key, member, value)).RunAsync();
        }

        public static Task<SortedSetEntry[]> SortedSetRangeByRankWithScoresAsyncWithRetries(this IDatabase database, RedisKey key)
        {
            return new RetryTask<SortedSetEntry[]>(() => database.SortedSetRangeByRankWithScoresAsync(key)).RunAsync();
        }

        public static Task<bool> ExecuteAsyncWithRetries(this ITransaction transaction, int retryCount = 3)
        {
            return new RetryTask<bool>(() => transaction.ExecuteAsync(), retryCount).RunAsync();
        }
    }
}
