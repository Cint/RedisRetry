using Moq;
using Shouldly;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;
using Xunit;

namespace RedisRetry.Test
{
    public class RedisRetryDatabaseSpec
    {
        private Mock<IDatabase> database;
        private RedisRetryDatabase retryDb;

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
        private long stop, end = 1337;
        private DateTime? expiry = DateTime.UtcNow.AddHours(3);
        private TimeSpan? timespan = TimeSpan.FromMinutes(18);
        private CommandFlags flags = CommandFlags.DemandSlave;
        private When when = When.Exists;
        private Order order = Order.Descending;

        public RedisRetryDatabaseSpec()
        {
            database = new Mock<IDatabase>();
            retryDb = new RedisRetryDatabase(database.Object);
        }

        [Fact]
        public void Should_throw_if_database_is_retry_database()
        {
            Should.Throw(() => new RedisRetryDatabase(new RedisRetryDatabase(database.Object)), typeof(ArgumentException));
        }

        [Fact]
        public async Task HashGetAsync()
        {
            await retryDb.HashGetAsync(key, hashField, flags);
            database.Verify(d => d.HashGetAsync(key, hashField, flags), Times.Once);

            await retryDb.HashGetAsync(key, values, flags);
            database.Verify(d => d.HashGetAsync(key, values, flags), Times.Once);
        }

        [Fact]
        public async Task HashSetAsync()
        {
            await retryDb.HashSetAsync(key, hashFields, flags);
            database.Verify(d => d.HashSetAsync(key, hashFields, flags), Times.Once);

            await retryDb.HashSetAsync(key, hashField, value, when, flags);
            database.Verify(d => d.HashSetAsync(key, hashField, value, when, flags), Times.Once);
        }

        [Fact]
        public async Task HashIncrementAsync()
        {
            await retryDb.HashIncrementAsync(key, hashField, dValue, flags);
            database.Verify(d => d.HashIncrementAsync(key, hashField, dValue, flags), Times.Once);

            await retryDb.HashIncrementAsync(key, hashField, lValue, flags);
            database.Verify(d => d.HashIncrementAsync(key, hashField, lValue, flags), Times.Once);

            await retryDb.HashIncrementAsync(key, hashField);
            database.Verify(d => d.HashIncrementAsync(key, hashField, 1, CommandFlags.None), Times.Once);
        }
    }
}
