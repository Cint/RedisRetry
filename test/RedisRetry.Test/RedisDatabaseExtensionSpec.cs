using Moq;
using StackExchange.Redis;
using System;
using Xunit;

namespace RedisRetry.Test
{
    public class RedisDatabaseExtensionSpec
    {
        private Mock<IDatabase> database = new Mock<IDatabase>();
        private RedisKey key = new RedisKey();
        private RedisKey[] keys = new RedisKey[] { new RedisKey() };
        private RedisValue value = new RedisValue();
        private RedisValue member = new RedisValue();
        private RedisValue[] values = new RedisValue[] { new RedisValue() };
        private double dValue = 0.28;
        private long lValue = 1234567890;
        private RedisValue hashField = new RedisValue();
        private HashEntry[] hashFields = new HashEntry[] { new HashEntry() };
        private long start = 3;
        private long stop,end = 1337;
        private DateTime? expiry = DateTime.UtcNow.AddHours(3);
        private TimeSpan? timespan = TimeSpan.FromMinutes(18);
        private CommandFlags flags = CommandFlags.HighPriority;
        private When when = When.NotExists;
        private Order order = Order.Descending;

        [Fact]
        public void HashSetAsyncWithRetries()
        {
            RedisDatabaseExtension.HashSetAsyncWithRetries(database.Object, key, hashFields, flags);
            database.Verify(d => d.HashSetAsync(key, hashFields, flags), Times.Once);

            RedisDatabaseExtension.HashSetAsyncWithRetries(database.Object, key, hashField, value, when, flags);
            database.Verify(d => d.HashSetAsync(key, hashField, value, when, flags), Times.Once);
        }

        [Fact]
        public void HashIncrementAsyncWithRetries()
        {
            RedisDatabaseExtension.HashIncrementAsyncWithRetries(database.Object, key, hashField, dValue, flags);
            database.Verify(d => d.HashIncrementAsync(key, hashField, dValue, flags), Times.Once);

            RedisDatabaseExtension.HashIncrementAsyncWithRetries(database.Object, key, hashField, lValue, flags);
            database.Verify(d => d.HashIncrementAsync(key, hashField, lValue, flags), Times.Once);
        }

        [Fact]
        public void HyperLogLogAddAsyncWithRetries()
        {
            RedisDatabaseExtension.HyperLogLogAddAsyncWithRetries(database.Object, key, value, flags);
            database.Verify(d => d.HyperLogLogAddAsync(key, value, flags), Times.Once);

            RedisDatabaseExtension.HyperLogLogAddAsyncWithRetries(database.Object, key, values, flags);
            database.Verify(d => d.HyperLogLogAddAsync(key, values, flags), Times.Once);
        }

        [Fact]
        public void HyperLogLogLengthAsyncWithRetries()
        {
            RedisDatabaseExtension.HyperLogLogLengthAsyncWithRetries(database.Object, key, flags);
            database.Verify(d => d.HyperLogLogLengthAsync(key, flags), Times.Once);

            RedisDatabaseExtension.HyperLogLogLengthAsyncWithRetries(database.Object, keys, flags);
            database.Verify(d => d.HyperLogLogLengthAsync(keys, flags), Times.Once);
        }

        [Fact]
        public void HashGetAsyncWithRetries()
        {
            RedisDatabaseExtension.HashGetAsyncWithRetries(database.Object, key, hashField, flags);
            database.Verify(d => d.HashGetAsync(key, hashField, flags), Times.Once);

            RedisDatabaseExtension.HashGetAsyncWithRetries(database.Object, key, values, flags);
            database.Verify(d => d.HashGetAsync(key, values, flags), Times.Once);
        }

        [Fact]
        public void HashGetAllAsyncWithRetries()
        {
            RedisDatabaseExtension.HashGetAllAsyncWithRetries(database.Object, key, flags);
            database.Verify(d => d.HashGetAllAsync(key, flags), Times.Once);
        }

        [Fact]
        public void KeyDeleteAsyncWithRetries()
        {
            RedisDatabaseExtension.KeyDeleteAsyncWithRetries(database.Object, key, flags);
            database.Verify(d => d.KeyDeleteAsync(key, flags), Times.Once);

            RedisDatabaseExtension.KeyDeleteAsyncWithRetries(database.Object, keys, flags);
            database.Verify(d => d.KeyDeleteAsync(keys, flags), Times.Once);
        }

        [Fact]
        public void KeyExpireAsyncWithRetries()
        {
            RedisDatabaseExtension.KeyExpireAsyncWithRetries(database.Object, key, expiry, flags);
            database.Verify(d => d.KeyExpireAsync(key, expiry, flags), Times.Once);

            RedisDatabaseExtension.KeyExpireAsyncWithRetries(database.Object, key, timespan, flags);
            database.Verify(d => d.KeyExpireAsync(key, timespan, flags), Times.Once);
        }

        [Fact]
        public void SortedSetIncrementAsyncWithRetries()
        {
            RedisDatabaseExtension.SortedSetIncrementAsyncWithRetries(database.Object, key, member, dValue, flags);
            database.Verify(d => d.SortedSetIncrementAsync(key, member, dValue, flags), Times.Once);
        }

        [Fact]
        public void SortedSetRangeByRankWithScoresAsyncWithRetries()
        {
            RedisDatabaseExtension.SortedSetRangeByRankWithScoresAsyncWithRetries(database.Object, key, start, stop, order, flags);
            database.Verify(d => d.SortedSetRangeByRankWithScoresAsync(key, start, stop, order, flags), Times.Once);
        }
    }
}
