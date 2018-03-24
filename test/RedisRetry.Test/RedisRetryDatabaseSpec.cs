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
        public async Task HashDeleteAsync()
        {
            await retryDb.HashDeleteAsync(key, hashField, flags);
            database.Verify(d => d.HashDeleteAsync(key, hashField, flags), Times.Once);

            await retryDb.HashDeleteAsync(key, hashField);
            database.Verify(d => d.HashDeleteAsync(key, hashField, CommandFlags.None), Times.Once);

            await retryDb.HashDeleteAsync(key, values, flags);
            database.Verify(d => d.HashDeleteAsync(key, values, flags), Times.Once);

            await retryDb.HashDeleteAsync(key, values);
            database.Verify(d => d.HashDeleteAsync(key, values, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task HashExistsAsync()
        {
            await retryDb.HashExistsAsync(key, hashField, flags);
            database.Verify(d => d.HashExistsAsync(key, hashField, flags), Times.Once);

            await retryDb.HashExistsAsync(key, hashField);
            database.Verify(d => d.HashExistsAsync(key, hashField, CommandFlags.None), Times.Once);
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
        public async Task HashGetAllAsync()
        {
            await retryDb.HashGetAllAsync(key, flags);
            database.Verify(d => d.HashGetAllAsync(key, flags));

            await retryDb.HashGetAllAsync(key);
            database.Verify(d => d.HashGetAllAsync(key, CommandFlags.None));
        }

        [Fact]
        public async Task HashSetAsync()
        {
            await retryDb.HashSetAsync(key, hashFields, flags);
            database.Verify(d => d.HashSetAsync(key, hashFields, flags), Times.Once);

            await retryDb.HashSetAsync(key, hashField, value, when, flags);
            database.Verify(d => d.HashSetAsync(key, hashField, value, when, flags), Times.Once);

            await retryDb.HashSetAsync(key, hashField, value, when);
            database.Verify(d => d.HashSetAsync(key, hashField, value, when, CommandFlags.None), Times.Once);

            await retryDb.HashSetAsync(key, hashField, value);
            database.Verify(d => d.HashSetAsync(key, hashField, value, When.Always, CommandFlags.None), Times.Once);
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

        [Fact]
        public async Task HashDecrementAsync()
        {
            await retryDb.HashDecrementAsync(key, hashField, dValue, flags);
            database.Verify(d => d.HashDecrementAsync(key, hashField, dValue, flags), Times.Once);

            await retryDb.HashDecrementAsync(key, hashField, lValue, flags);
            database.Verify(d => d.HashDecrementAsync(key, hashField, lValue, flags), Times.Once);

            await retryDb.HashDecrementAsync(key, hashField);
            database.Verify(d => d.HashDecrementAsync(key, hashField, 1, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task HashKeysAsync()
        {
            await retryDb.HashKeysAsync(key, flags);
            database.Verify(d => d.HashKeysAsync(key, flags), Times.Once);

            await retryDb.HashKeysAsync(key);
            database.Verify(d => d.HashKeysAsync(key, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task HashLengthAsync()
        {
            await retryDb.HashLengthAsync(key, flags);
            database.Verify(d => d.HashLengthAsync(key, flags), Times.Once);

            await retryDb.HashLengthAsync(key);
            database.Verify(d => d.HashLengthAsync(key, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task HashValuesAsync()
        {
            await retryDb.HashValuesAsync(key, flags);
            database.Verify(d => d.HashValuesAsync(key, flags), Times.Once);

            await retryDb.HashValuesAsync(key);
            database.Verify(d => d.HashValuesAsync(key, CommandFlags.None), Times.Once);
        }



    }
}
