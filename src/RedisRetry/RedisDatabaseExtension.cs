using System;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace RedisRetry
{
    public static class RedisDatabaseExtension
    {
        public static Task<bool> HashSetAsyncWithRetries(this IDatabase database, RedisKey key, RedisValue hashField, RedisValue value, When when = When.Always, CommandFlags flags = CommandFlags.None)
        {
            return new RedisRetryTask<bool>(() => database.HashSetAsync(key, hashField, value, when, flags)).RunAsync();
        }

        public static Task HashSetAsyncWithRetries(this IDatabase database, RedisKey key, HashEntry[] hashFields,CommandFlags flags = CommandFlags.None)
        {
            return new RetryTask(() => database.HashSetAsync(key, hashFields, flags)).RunAsync();
        }

        public static Task<long> HashIncrementAsyncWithRetries(this IDatabaseAsync database, RedisKey key, RedisValue hashField, long value, CommandFlags flags = CommandFlags.None)
        {
            return new RedisRetryTask<long>(() => database.HashIncrementAsync(key, hashField, value, flags)).RunAsync();
        }

        public static Task<double> HashIncrementAsyncWithRetries(this IDatabaseAsync database, RedisKey key, RedisValue hashField, double value, CommandFlags flags = CommandFlags.None)
        {
            return new RedisRetryTask<double>(() => database.HashIncrementAsync(key, hashField, value, flags)).RunAsync();
        }

        public static Task<bool> HyperLogLogAddAsyncWithRetries(this IDatabase database, RedisKey key, RedisValue value, CommandFlags flags = CommandFlags.None)
        {
            return new RedisRetryTask<bool>(() => database.HyperLogLogAddAsync(key, value, flags)).RunAsync();
        }

        public static Task<bool> HyperLogLogAddAsyncWithRetries(this IDatabase database, RedisKey key, RedisValue[] values, CommandFlags flags = CommandFlags.None)
        {
            return new RedisRetryTask<bool>(() => database.HyperLogLogAddAsync(key, values, flags)).RunAsync();
        }

        public static Task<long> HyperLogLogLengthAsyncWithRetries(this IDatabase database, RedisKey key, CommandFlags flags = CommandFlags.None)
        {
            return new RedisRetryTask<long>(() => database.HyperLogLogLengthAsync(key, flags)).RunAsync();
        }

        public static Task<long> HyperLogLogLengthAsyncWithRetries(this IDatabase database, RedisKey[] keys, CommandFlags flags = CommandFlags.None)
        {
            return new RedisRetryTask<long>(() => database.HyperLogLogLengthAsync(keys, flags)).RunAsync();
        }

        public static Task<RedisValue> HashGetAsyncWithRetries(this IDatabase database, RedisKey key, RedisValue hashField, CommandFlags flags = CommandFlags.None)
        {
            return new RedisRetryTask<RedisValue>(() => database.HashGetAsync(key, hashField, flags)).RunAsync();
        }

        public static Task<RedisValue[]> HashGetAsyncWithRetries(this IDatabase database, RedisKey key, RedisValue[] hashFields, CommandFlags flags = CommandFlags.None)
        {
            return new RedisRetryTask<RedisValue[]>(() => database.HashGetAsync(key, hashFields, flags)).RunAsync();
        }

        public static Task<HashEntry[]> HashGetAllAsyncWithRetries(this IDatabase database, RedisKey key, CommandFlags flags = CommandFlags.None)
        {
            return new RedisRetryTask<HashEntry[]>(() => database.HashGetAllAsync(key, flags)).RunAsync();
        }

        public static Task<bool> KeyDeleteAsyncWithRetries(this IDatabase database, RedisKey key, CommandFlags flags = CommandFlags.None)
        {
            return new RedisRetryTask<bool>(() => database.KeyDeleteAsync(key, flags)).RunAsync();
        }

        public static Task<long> KeyDeleteAsyncWithRetries(this IDatabase database, RedisKey[] keys, CommandFlags flags = CommandFlags.None)
        {
            return new RedisRetryTask<long>(() => database.KeyDeleteAsync(keys, flags)).RunAsync();
        }

        public static Task<bool> KeyExpireAsyncWithRetries(this IDatabase database, RedisKey key, TimeSpan? timespan, CommandFlags flags = CommandFlags.None)
        {
            return new RedisRetryTask<bool>(() => database.KeyExpireAsync(key, timespan, flags)).RunAsync();
        }

        public static Task<bool> KeyExpireAsyncWithRetries(this IDatabase database, RedisKey key, DateTime? expiry, CommandFlags flags = CommandFlags.None)
        {
            return new RedisRetryTask<bool>(() => database.KeyExpireAsync(key, expiry, flags)).RunAsync();
        }

        public static Task<double> SortedSetIncrementAsyncWithRetries(this IDatabase database, RedisKey key, RedisValue member, double value, CommandFlags flags = CommandFlags.None)
        {
            return new RedisRetryTask<double>(() => database.SortedSetIncrementAsync(key, member, value, flags)).RunAsync();
        }

        public static Task<SortedSetEntry[]> SortedSetRangeByRankWithScoresAsyncWithRetries(this IDatabase database, RedisKey key, long start = 0, long stop = 0, Order order = Order.Ascending, CommandFlags flags = CommandFlags.None)
        {
            return new RedisRetryTask<SortedSetEntry[]>(() => database.SortedSetRangeByRankWithScoresAsync(key, start, stop, order, flags)).RunAsync();
        }
    }
}
