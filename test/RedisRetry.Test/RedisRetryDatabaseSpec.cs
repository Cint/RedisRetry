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
        private SortedSetEntry[] entries = new SortedSetEntry[] { new SortedSetEntry() };
        private RedisValue member = new RedisValue();
        private RedisValue[] values = new RedisValue[] { new RedisValue() };
        private double dValue = 0.28;
        private long lValue = 1234567890;
        private RedisValue hashField = new RedisValue();
        private HashEntry[] hashFields = new HashEntry[] { new HashEntry() };
        private int take = 37;
        private int skip = 14;
        private double min = 1.18;
        private double max = 390.18;
        private long start = 3;
        private long stop, end = 1337;
        private DateTime? expiry = DateTime.UtcNow.AddHours(3);
        private TimeSpan? timespan = TimeSpan.FromMinutes(18);
        private CommandFlags flags = CommandFlags.DemandSlave;
        private When when = When.Exists;
        private Order order = Order.Descending;
        Exclude exclude = Exclude.Both;

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

        [Fact]
        public async Task KeyDumpAsync()
        {
            await retryDb.KeyDumpAsync(key, flags);
            database.Verify(d => d.KeyDumpAsync(key, flags), Times.Once);

            await retryDb.KeyDumpAsync(key);
            database.Verify(d => d.KeyDumpAsync(key, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task KeyExistsAsync()
        {
            await retryDb.KeyExistsAsync(key, flags);
            database.Verify(d => d.KeyExistsAsync(key, flags), Times.Once);

            await retryDb.KeyExistsAsync(key);
            database.Verify(d => d.KeyExistsAsync(key, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task KeyExpireAsync()
        {
            await retryDb.KeyExpireAsync(key, expiry, flags);
            database.Verify(d => d.KeyExpireAsync(key, expiry, flags), Times.Once);

            await retryDb.KeyExpireAsync(key, expiry);
            database.Verify(d => d.KeyExpireAsync(key, expiry, CommandFlags.None), Times.Once);

            await retryDb.KeyExpireAsync(key, timespan, flags);
            database.Verify(d => d.KeyExpireAsync(key, timespan, flags), Times.Once);

            await retryDb.KeyExpireAsync(key, timespan);
            database.Verify(d => d.KeyExpireAsync(key, timespan, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task KeyDeleteAsync()
        {
            await retryDb.KeyDeleteAsync(key, flags);
            database.Verify(d => d.KeyDeleteAsync(key, flags), Times.Once);

            await retryDb.KeyDeleteAsync(key);
            database.Verify(d => d.KeyDeleteAsync(key, CommandFlags.None), Times.Once);

            await retryDb.KeyDeleteAsync(keys, flags);
            database.Verify(d => d.KeyDeleteAsync(keys, flags), Times.Once);

            await retryDb.KeyDeleteAsync(keys);
            database.Verify(d => d.KeyDeleteAsync(keys, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task HyperLogLogAddAsync()
        {
            await retryDb.HyperLogLogAddAsync(key, value, flags);
            database.Verify(d => d.HyperLogLogAddAsync(key, value, flags), Times.Once);

            await retryDb.HyperLogLogAddAsync(key, value);
            database.Verify(d => d.HyperLogLogAddAsync(key, value, CommandFlags.None), Times.Once);

            await retryDb.HyperLogLogAddAsync(key, values, flags);
            database.Verify(d => d.HyperLogLogAddAsync(key, values, flags), Times.Once);

            await retryDb.HyperLogLogAddAsync(key, values);
            database.Verify(d => d.HyperLogLogAddAsync(key, values, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task HyperLogLogMergeAsync()
        {
            await retryDb.HyperLogLogMergeAsync(key, keys, flags);
            database.Verify(d => d.HyperLogLogMergeAsync(key, keys, flags), Times.Once);

            await retryDb.HyperLogLogMergeAsync(key, keys);
            database.Verify(d => d.HyperLogLogMergeAsync(key, keys, CommandFlags.None), Times.Once);

            await retryDb.HyperLogLogMergeAsync(key, key, key, flags);
            database.Verify(d => d.HyperLogLogMergeAsync(key, key, key, flags), Times.Once);

            await retryDb.HyperLogLogMergeAsync(key, key, key);
            database.Verify(d => d.HyperLogLogMergeAsync(key, key, key, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task HyperLogLogLengthAsync()
        {
            await retryDb.HyperLogLogLengthAsync(key, flags);
            database.Verify(d => d.HyperLogLogLengthAsync(key, flags), Times.Once);

            await retryDb.HyperLogLogLengthAsync(key);
            database.Verify(d => d.HyperLogLogLengthAsync(key, CommandFlags.None), Times.Once);

            await retryDb.HyperLogLogLengthAsync(keys, flags);
            database.Verify(d => d.HyperLogLogLengthAsync(keys, flags), Times.Once);

            await retryDb.HyperLogLogLengthAsync(keys);
            database.Verify(d => d.HyperLogLogLengthAsync(keys, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task SortedSetAddAsync()
        {
            await retryDb.SortedSetAddAsync(key, entries, when, flags);
            database.Verify(d => d.SortedSetAddAsync(key, entries, when, flags), Times.Once);

            await retryDb.SortedSetAddAsync(key, entries, flags);
            database.Verify(d => d.SortedSetAddAsync(key, entries, flags), Times.Once);

            await retryDb.SortedSetAddAsync(key, entries);
            database.Verify(d => d.SortedSetAddAsync(key, entries, When.Always, CommandFlags.None), Times.Once);

            await retryDb.SortedSetAddAsync(key, value, dValue, when, flags);
            database.Verify(d => d.SortedSetAddAsync(key, value, dValue, when, flags), Times.Once);

            await retryDb.SortedSetAddAsync(key, value, dValue, when);
            database.Verify(d => d.SortedSetAddAsync(key, value, dValue, when, CommandFlags.None), Times.Once);

            await retryDb.SortedSetAddAsync(key, value, dValue);
            database.Verify(d => d.SortedSetAddAsync(key, value, dValue, When.Always, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task SortedSetDecrementAsync()
        {
            await retryDb.SortedSetDecrementAsync(key, value, dValue, flags);
            database.Verify(d => d.SortedSetDecrementAsync(key, value, dValue, flags), Times.Once);

            await retryDb.SortedSetDecrementAsync(key, value, dValue);
            database.Verify(d => d.SortedSetDecrementAsync(key, value, dValue, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task SortedSetIncrementAsync()
        {
            await retryDb.SortedSetIncrementAsync(key, value, dValue, flags);
            database.Verify(d => d.SortedSetIncrementAsync(key, value, dValue, flags), Times.Once);

            await retryDb.SortedSetIncrementAsync(key, value, dValue);
            database.Verify(d => d.SortedSetIncrementAsync(key, value, dValue, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task SortedSetLengthAsync()
        {
            await retryDb.SortedSetLengthAsync(key, min, max, exclude, flags);
            database.Verify(d => d.SortedSetLengthAsync(key, min, max, exclude, flags), Times.Once);

            await retryDb.SortedSetLengthAsync(key, min, max, exclude);
            database.Verify(d => d.SortedSetLengthAsync(key, min, max, exclude, CommandFlags.None), Times.Once);

            await retryDb.SortedSetLengthAsync(key, min, max);
            database.Verify(d => d.SortedSetLengthAsync(key, min, max, Exclude.None, CommandFlags.None), Times.Once);

            await retryDb.SortedSetLengthAsync(key, min);
            database.Verify(d => d.SortedSetLengthAsync(key, min, Double.PositiveInfinity, Exclude.None, CommandFlags.None), Times.Once);

            await retryDb.SortedSetLengthAsync(key);
            database.Verify(d => d.SortedSetLengthAsync(key, Double.NegativeInfinity, Double.PositiveInfinity, Exclude.None, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task SortedSetLengthByValueAsync()
        {
            await retryDb.SortedSetLengthByValueAsync(key, min, max, exclude, flags);
            database.Verify(d => d.SortedSetLengthByValueAsync(key, min, max, exclude, flags), Times.Once);

            await retryDb.SortedSetLengthByValueAsync(key, min, max, exclude);
            database.Verify(d => d.SortedSetLengthByValueAsync(key, min, max, exclude, CommandFlags.None), Times.Once);

            await retryDb.SortedSetLengthByValueAsync(key, min, max);
            database.Verify(d => d.SortedSetLengthByValueAsync(key, min, max, Exclude.None, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task SortedSetRangeByRankAsync()
        {
            await retryDb.SortedSetRangeByRankAsync(key, start, stop, order, flags);
            database.Verify(d => d.SortedSetRangeByRankAsync(key, start, stop, order, flags), Times.Once);

            await retryDb.SortedSetRangeByRankAsync(key, start, stop, order);
            database.Verify(d => d.SortedSetRangeByRankAsync(key, start, stop, order, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByRankAsync(key, start, stop);
            database.Verify(d => d.SortedSetRangeByRankAsync(key, start, stop, Order.Ascending, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByRankAsync(key, start);
            database.Verify(d => d.SortedSetRangeByRankAsync(key, start, -1, Order.Ascending, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByRankAsync(key);
            database.Verify(d => d.SortedSetRangeByRankAsync(key, 0, -1, Order.Ascending, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task SortedSetRangeByRankWithScoresAsync()
        {
            await retryDb.SortedSetRangeByRankWithScoresAsync(key, start, stop, order, flags);
            database.Verify(d => d.SortedSetRangeByRankWithScoresAsync(key, start, stop, order, flags), Times.Once);

            await retryDb.SortedSetRangeByRankWithScoresAsync(key, start, stop, order);
            database.Verify(d => d.SortedSetRangeByRankWithScoresAsync(key, start, stop, order, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByRankWithScoresAsync(key, start, stop);
            database.Verify(d => d.SortedSetRangeByRankWithScoresAsync(key, start, stop, Order.Ascending, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByRankWithScoresAsync(key, start);
            database.Verify(d => d.SortedSetRangeByRankWithScoresAsync(key, start, -1, Order.Ascending, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByRankWithScoresAsync(key);
            database.Verify(d => d.SortedSetRangeByRankWithScoresAsync(key, 0, -1, Order.Ascending, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task SortedSetRangeByScoreAsync()
        {
            await retryDb.SortedSetRangeByScoreAsync(key, start, stop, exclude, order, skip, take, flags);
            database.Verify(d => d.SortedSetRangeByScoreAsync(key, start, stop, exclude, order, skip, take, flags), Times.Once);

            await retryDb.SortedSetRangeByScoreAsync(key, start, stop, exclude, order, skip, take);
            database.Verify(d => d.SortedSetRangeByScoreAsync(key, start, stop, exclude, order, skip, take, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByScoreAsync(key, start, stop, exclude, order, skip);
            database.Verify(d => d.SortedSetRangeByScoreAsync(key, start, stop, exclude, order, skip, -1, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByScoreAsync(key, start, stop, exclude, order);
            database.Verify(d => d.SortedSetRangeByScoreAsync(key, start, stop, exclude, order, 0, -1, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByScoreAsync(key, start, stop, exclude);
            database.Verify(d => d.SortedSetRangeByScoreAsync(key, start, stop, exclude, Order.Ascending, 0, -1, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByScoreAsync(key, start, stop);
            database.Verify(d => d.SortedSetRangeByScoreAsync(key, start, stop, Exclude.None, Order.Ascending, 0, -1, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByScoreAsync(key, start);
            database.Verify(d => d.SortedSetRangeByScoreAsync(key, start, Double.PositiveInfinity, Exclude.None, Order.Ascending, 0, -1, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByScoreAsync(key);
            database.Verify(d => d.SortedSetRangeByScoreAsync(key, Double.NegativeInfinity, Double.PositiveInfinity, Exclude.None, Order.Ascending, 0, -1, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task SortedSetRangeByScoreWithScoresAsync()
        {
            await retryDb.SortedSetRangeByScoreWithScoresAsync(key, start, stop, exclude, order, skip, take, flags);
            database.Verify(d => d.SortedSetRangeByScoreWithScoresAsync(key, start, stop, exclude, order, skip, take, flags), Times.Once);

            await retryDb.SortedSetRangeByScoreWithScoresAsync(key, start, stop, exclude, order, skip, take);
            database.Verify(d => d.SortedSetRangeByScoreWithScoresAsync(key, start, stop, exclude, order, skip, take, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByScoreWithScoresAsync(key, start, stop, exclude, order, skip);
            database.Verify(d => d.SortedSetRangeByScoreWithScoresAsync(key, start, stop, exclude, order, skip, -1, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByScoreWithScoresAsync(key, start, stop, exclude, order);
            database.Verify(d => d.SortedSetRangeByScoreWithScoresAsync(key, start, stop, exclude, order, 0, -1, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByScoreWithScoresAsync(key, start, stop, exclude);
            database.Verify(d => d.SortedSetRangeByScoreWithScoresAsync(key, start, stop, exclude, Order.Ascending, 0, -1, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByScoreWithScoresAsync(key, start, stop);
            database.Verify(d => d.SortedSetRangeByScoreWithScoresAsync(key, start, stop, Exclude.None, Order.Ascending, 0, -1, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByScoreWithScoresAsync(key, start);
            database.Verify(d => d.SortedSetRangeByScoreWithScoresAsync(key, start, Double.PositiveInfinity, Exclude.None, Order.Ascending, 0, -1, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByScoreWithScoresAsync(key);
            database.Verify(d => d.SortedSetRangeByScoreWithScoresAsync(key, Double.NegativeInfinity, Double.PositiveInfinity, Exclude.None, Order.Ascending, 0, -1, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task SortedSetRangeByValueAsync()
        {
            await retryDb.SortedSetRangeByValueAsync(key, min, max, exclude, skip, take, flags);
            database.Verify(d => d.SortedSetRangeByValueAsync(key, min, max, exclude, skip, take, flags), Times.Once);

            await retryDb.SortedSetRangeByValueAsync(key, min, max, exclude, skip, take);
            database.Verify(d => d.SortedSetRangeByValueAsync(key, min, max, exclude, skip, take, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByValueAsync(key, min, max, exclude, skip);
            database.Verify(d => d.SortedSetRangeByValueAsync(key, min, max, exclude, skip, -1, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByValueAsync(key, min, max, exclude);
            database.Verify(d => d.SortedSetRangeByValueAsync(key, min, max, exclude, 0, -1, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByValueAsync(key, min, max);
            database.Verify(d => d.SortedSetRangeByValueAsync(key, min, max, Exclude.None, 0, -1, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByValueAsync(key, min);
            database.Verify(d => d.SortedSetRangeByValueAsync(key, min, default(RedisValue), Exclude.None, 0, -1, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRangeByValueAsync(key);
            database.Verify(d => d.SortedSetRangeByValueAsync(key, default(RedisValue), default(RedisValue), Exclude.None, 0, -1, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task SortedSetRankAsync()
        {
            await retryDb.SortedSetRankAsync(key,value, order, flags);
            database.Verify(d => d.SortedSetRankAsync(key, value, order, flags), Times.Once);

            await retryDb.SortedSetRankAsync(key, value, order);
            database.Verify(d => d.SortedSetRankAsync(key, value, order, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRankAsync(key, value);
            database.Verify(d => d.SortedSetRankAsync(key, value, Order.Ascending, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task SortedSetRemoveAsync()
        {
            await retryDb.SortedSetRemoveAsync(key, value, flags);
            database.Verify(d => d.SortedSetRemoveAsync(key, value, flags), Times.Once);

            await retryDb.SortedSetRemoveAsync(key, value);
            database.Verify(d => d.SortedSetRemoveAsync(key, value, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRemoveAsync(key, values, flags);
            database.Verify(d => d.SortedSetRemoveAsync(key, values, flags), Times.Once);

            await retryDb.SortedSetRemoveAsync(key, values);
            database.Verify(d => d.SortedSetRemoveAsync(key, values, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task SortedSetRemoveRangeByRankAsync()
        {
            await retryDb.SortedSetRemoveRangeByRankAsync(key, start, stop, flags);
            database.Verify(d => d.SortedSetRemoveRangeByRankAsync(key, start, stop, flags), Times.Once);

            await retryDb.SortedSetRemoveRangeByRankAsync(key, start, stop);
            database.Verify(d => d.SortedSetRemoveRangeByRankAsync(key, start, stop, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task SortedSetRemoveRangeByScoreAsync()
        {
            await retryDb.SortedSetRemoveRangeByScoreAsync(key, start, stop, exclude, flags);
            database.Verify(d => d.SortedSetRemoveRangeByScoreAsync(key, start, stop, exclude, flags), Times.Once);

            await retryDb.SortedSetRemoveRangeByScoreAsync(key, start, stop, exclude);
            database.Verify(d => d.SortedSetRemoveRangeByScoreAsync(key, start, stop, exclude, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRemoveRangeByScoreAsync(key, start, stop);
            database.Verify(d => d.SortedSetRemoveRangeByScoreAsync(key, start, stop, Exclude.None, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task SortedSetRemoveRangeByValueAsync()
        {
            await retryDb.SortedSetRemoveRangeByValueAsync(key, min, max, exclude, flags);
            database.Verify(d => d.SortedSetRemoveRangeByValueAsync(key, min, max, exclude, flags), Times.Once);

            await retryDb.SortedSetRemoveRangeByValueAsync(key, min, max, exclude);
            database.Verify(d => d.SortedSetRemoveRangeByValueAsync(key, min, max, exclude, CommandFlags.None), Times.Once);

            await retryDb.SortedSetRemoveRangeByValueAsync(key, min, max);
            database.Verify(d => d.SortedSetRemoveRangeByValueAsync(key, min, max, Exclude.None, CommandFlags.None), Times.Once);
        }

        [Fact]
        public async Task SortedSetScoreAsync()
        {
            await retryDb.SortedSetScoreAsync(key, value, flags);
            database.Verify(d => d.SortedSetScoreAsync(key, value, flags), Times.Once);

            await retryDb.SortedSetScoreAsync(key, value);
            database.Verify(d => d.SortedSetScoreAsync(key, value, CommandFlags.None), Times.Once);
        }
    }
}
