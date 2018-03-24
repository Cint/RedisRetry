using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RedisRetry
{
    public class RedisRetryDatabase : IRedisRetryDatabase
    {
        private readonly IDatabase _database;

        public RedisRetryDatabase(IDatabase database)
        {
            if (database.GetType() == typeof(RedisRetryDatabase))
            {
                throw new ArgumentException("can not be of type RedisRetryDatabase", nameof(database));
            }
            _database = database;
        }

        public int Database => _database.Database;

        public ConnectionMultiplexer Multiplexer => _database.Multiplexer;

        public IBatch CreateBatch(object asyncState = null)
            => _database.CreateBatch(asyncState);

        public ITransaction CreateTransaction(object asyncState = null)
            => _database.CreateTransaction(asyncState);

        public RedisValue DebugObject(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.DebugObject(key, flags);

        public Task<RedisValue> DebugObjectAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.DebugObjectAsync(key, flags);

        public RedisResult Execute(string command, params object[] args)
            => _database.Execute(command, args);

        public RedisResult Execute(string command, ICollection<object> args, CommandFlags flags = CommandFlags.None)
            => _database.Execute(command, args, flags);

        public Task<RedisResult> ExecuteAsync(string command, params object[] args)
            => _database.ExecuteAsync(command, args);

        public Task<RedisResult> ExecuteAsync(string command, ICollection<object> args, CommandFlags flags = CommandFlags.None)
            => _database.ExecuteAsync(command, args, flags);

        public bool GeoAdd(RedisKey key, double longitude, double latitude, RedisValue member, CommandFlags flags = CommandFlags.None)
            => _database.GeoAdd(key, longitude, latitude, member, flags);

        public bool GeoAdd(RedisKey key, GeoEntry value, CommandFlags flags = CommandFlags.None)
            => _database.GeoAdd(key, value, flags);

        public long GeoAdd(RedisKey key, GeoEntry[] values, CommandFlags flags = CommandFlags.None)
            => _database.GeoAdd(key, values, flags);

        public Task<bool> GeoAddAsync(RedisKey key, double longitude, double latitude, RedisValue member, CommandFlags flags = CommandFlags.None)
            => _database.GeoAddAsync(key, longitude, latitude, member, flags);

        public Task<bool> GeoAddAsync(RedisKey key, GeoEntry value, CommandFlags flags = CommandFlags.None)
            => _database.GeoAddAsync(key, value, flags);

        public Task<long> GeoAddAsync(RedisKey key, GeoEntry[] values, CommandFlags flags = CommandFlags.None)
            => _database.GeoAddAsync(key, values, flags);

        public double? GeoDistance(RedisKey key, RedisValue member1, RedisValue member2, GeoUnit unit = GeoUnit.Meters, CommandFlags flags = CommandFlags.None)
            => _database.GeoDistance(key, member1, member2, unit, flags);

        public Task<double?> GeoDistanceAsync(RedisKey key, RedisValue member1, RedisValue member2, GeoUnit unit = GeoUnit.Meters, CommandFlags flags = CommandFlags.None)
            => _database.GeoDistanceAsync(key, member1, member2, unit, flags);

        public string[] GeoHash(RedisKey key, RedisValue[] members, CommandFlags flags = CommandFlags.None)
            => _database.GeoHash(key, members, flags);

        public string GeoHash(RedisKey key, RedisValue member, CommandFlags flags = CommandFlags.None)
            => _database.GeoHash(key, member, flags);

        public Task<string[]> GeoHashAsync(RedisKey key, RedisValue[] members, CommandFlags flags = CommandFlags.None)
            => _database.GeoHashAsync(key, members, flags);

        public Task<string> GeoHashAsync(RedisKey key, RedisValue member, CommandFlags flags = CommandFlags.None)
            => _database.GeoHashAsync(key, member, flags);

        public GeoPosition?[] GeoPosition(RedisKey key, RedisValue[] members, CommandFlags flags = CommandFlags.None)
            => _database.GeoPosition(key, members, flags);

        public GeoPosition? GeoPosition(RedisKey key, RedisValue member, CommandFlags flags = CommandFlags.None)
            => _database.GeoPosition(key, member, flags);

        public Task<GeoPosition?[]> GeoPositionAsync(RedisKey key, RedisValue[] members, CommandFlags flags = CommandFlags.None)
            => _database.GeoPositionAsync(key, members, flags);

        public Task<GeoPosition?> GeoPositionAsync(RedisKey key, RedisValue member, CommandFlags flags = CommandFlags.None)
            => _database.GeoPositionAsync(key, member, flags);

        public GeoRadiusResult[] GeoRadius(RedisKey key, RedisValue member, double radius, GeoUnit unit = GeoUnit.Meters, int count = -1, Order? order = null, GeoRadiusOptions options = GeoRadiusOptions.Default, CommandFlags flags = CommandFlags.None)
            => _database.GeoRadius(key, member, radius, unit, count, order, options, flags);

        public GeoRadiusResult[] GeoRadius(RedisKey key, double longitude, double latitude, double radius, GeoUnit unit = GeoUnit.Meters, int count = -1, Order? order = null, GeoRadiusOptions options = GeoRadiusOptions.Default, CommandFlags flags = CommandFlags.None)
            => _database.GeoRadius(key, longitude, latitude, radius, unit, count, order, options, flags);

        public Task<GeoRadiusResult[]> GeoRadiusAsync(RedisKey key, RedisValue member, double radius, GeoUnit unit = GeoUnit.Meters, int count = -1, Order? order = null, GeoRadiusOptions options = GeoRadiusOptions.Default, CommandFlags flags = CommandFlags.None)
            => _database.GeoRadiusAsync(key, member, radius, unit, count, order, options, flags);

        public Task<GeoRadiusResult[]> GeoRadiusAsync(RedisKey key, double longitude, double latitude, double radius, GeoUnit unit = GeoUnit.Meters, int count = -1, Order? order = null, GeoRadiusOptions options = GeoRadiusOptions.Default, CommandFlags flags = CommandFlags.None)
            => _database.GeoRadiusAsync(key, longitude, latitude, radius, unit, count, order, options, flags);

        public bool GeoRemove(RedisKey key, RedisValue member, CommandFlags flags = CommandFlags.None)
            => _database.GeoRemove(key, member, flags);

        public Task<bool> GeoRemoveAsync(RedisKey key, RedisValue member, CommandFlags flags = CommandFlags.None)
            => _database.GeoRemoveAsync(key, member, flags);

        public long HashDecrement(RedisKey key, RedisValue hashField, long value = 1, CommandFlags flags = CommandFlags.None)
            => _database.HashDecrement(key, hashField, value, flags);

        public double HashDecrement(RedisKey key, RedisValue hashField, double value, CommandFlags flags = CommandFlags.None)
            => _database.HashDecrement(key, hashField, value, flags);

        public Task<long> HashDecrementAsync(RedisKey key, RedisValue hashField, long value = 1, CommandFlags flags = CommandFlags.None)
            => _database.HashDecrementAsync(key, hashField, value, flags);

        public Task<double> HashDecrementAsync(RedisKey key, RedisValue hashField, double value, CommandFlags flags = CommandFlags.None)
            => _database.HashDecrementAsync(key, hashField, value, flags);

        public bool HashDelete(RedisKey key, RedisValue hashField, CommandFlags flags = CommandFlags.None)
            => _database.HashDelete(key, hashField, flags);

        public long HashDelete(RedisKey key, RedisValue[] hashFields, CommandFlags flags = CommandFlags.None)
            => _database.HashDelete(key, hashFields, flags);

        public Task<bool> HashDeleteAsync(RedisKey key, RedisValue hashField, CommandFlags flags = CommandFlags.None)
            => _database.HashDeleteAsync(key, hashField, flags);

        public Task<long> HashDeleteAsync(RedisKey key, RedisValue[] hashFields, CommandFlags flags = CommandFlags.None)
            => _database.HashDeleteAsync(key, hashFields, flags);

        public bool HashExists(RedisKey key, RedisValue hashField, CommandFlags flags = CommandFlags.None)
            => _database.HashExists(key, hashField, flags);

        public Task<bool> HashExistsAsync(RedisKey key, RedisValue hashField, CommandFlags flags = CommandFlags.None)
            => _database.HashExistsAsync(key, hashField, flags);

        public RedisValue HashGet(RedisKey key, RedisValue hashField, CommandFlags flags = CommandFlags.None)
            => _database.HashGet(key, hashField, flags);

        public RedisValue[] HashGet(RedisKey key, RedisValue[] hashFields, CommandFlags flags = CommandFlags.None)
            => _database.HashGet(key, hashFields, flags);

        public HashEntry[] HashGetAll(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.HashGetAll(key, flags);

        public Task<HashEntry[]> HashGetAllAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.HashGetAllAsync(key, flags);

        public Task<RedisValue> HashGetAsync(RedisKey key, RedisValue hashField, CommandFlags flags = CommandFlags.None)
            => _database.HashGetAsyncWithRetries(key, hashField, flags);

        public Task<RedisValue[]> HashGetAsync(RedisKey key, RedisValue[] hashFields, CommandFlags flags = CommandFlags.None)
            => _database.HashGetAsyncWithRetries(key, hashFields, flags);

        public long HashIncrement(RedisKey key, RedisValue hashField, long value = 1, CommandFlags flags = CommandFlags.None)
            => _database.HashIncrement(key, hashField, value, flags);

        public double HashIncrement(RedisKey key, RedisValue hashField, double value, CommandFlags flags = CommandFlags.None)
            => _database.HashIncrement(key, hashField, value, flags);

        public Task<long> HashIncrementAsync(RedisKey key, RedisValue hashField, long value = 1, CommandFlags flags = CommandFlags.None)
            => _database.HashIncrementAsync(key, hashField, value, flags);

        public Task<double> HashIncrementAsync(RedisKey key, RedisValue hashField, double value, CommandFlags flags = CommandFlags.None)
            => _database.HashIncrementAsync(key, hashField, value, flags);

        public RedisValue[] HashKeys(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.HashKeys(key, flags);

        public Task<RedisValue[]> HashKeysAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.HashKeysAsync(key, flags);

        public long HashLength(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.HashLength(key, flags);

        public Task<long> HashLengthAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.HashLengthAsync(key, flags);

        public IEnumerable<HashEntry> HashScan(RedisKey key, RedisValue pattern, int pageSize, CommandFlags flags)
            => _database.HashScan(key, pattern, pageSize, flags);

        public IEnumerable<HashEntry> HashScan(RedisKey key, RedisValue pattern = default(RedisValue), int pageSize = 10, long cursor = 0, int pageOffset = 0, CommandFlags flags = CommandFlags.None)
            => _database.HashScan(key, pattern, pageSize, cursor, pageOffset, flags);

        public void HashSet(RedisKey key, HashEntry[] hashFields, CommandFlags flags = CommandFlags.None)
            => _database.HashSet(key, hashFields, flags);

        public bool HashSet(RedisKey key, RedisValue hashField, RedisValue value, When when = When.Always, CommandFlags flags = CommandFlags.None)
            => _database.HashSet(key, hashField, value, when, flags);

        public Task HashSetAsync(RedisKey key, HashEntry[] hashFields, CommandFlags flags = CommandFlags.None)
            => _database.HashSetAsync(key, hashFields, flags);

        public Task<bool> HashSetAsync(RedisKey key, RedisValue hashField, RedisValue value, When when = When.Always, CommandFlags flags = CommandFlags.None)
            => _database.HashSetAsync(key, hashField, value, when, flags);

        public RedisValue[] HashValues(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.HashValues(key, flags);

        public Task<RedisValue[]> HashValuesAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.HashValuesAsync(key, flags);

        public bool HyperLogLogAdd(RedisKey key, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.HyperLogLogAdd(key, value, flags);

        public bool HyperLogLogAdd(RedisKey key, RedisValue[] values, CommandFlags flags = CommandFlags.None)
            => _database.HyperLogLogAdd(key, values, flags);

        public Task<bool> HyperLogLogAddAsync(RedisKey key, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.HyperLogLogAddAsync(key, value, flags);

        public Task<bool> HyperLogLogAddAsync(RedisKey key, RedisValue[] values, CommandFlags flags = CommandFlags.None)
            => _database.HyperLogLogAddAsync(key, values, flags);

        public long HyperLogLogLength(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.HyperLogLogLength(key, flags);

        public long HyperLogLogLength(RedisKey[] keys, CommandFlags flags = CommandFlags.None)
            => _database.HyperLogLogLength(keys, flags);

        public Task<long> HyperLogLogLengthAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.HyperLogLogLengthAsync(key, flags);

        public Task<long> HyperLogLogLengthAsync(RedisKey[] keys, CommandFlags flags = CommandFlags.None)
            => _database.HyperLogLogLengthAsync(keys, flags);

        public void HyperLogLogMerge(RedisKey destination, RedisKey first, RedisKey second, CommandFlags flags = CommandFlags.None)
            => _database.HyperLogLogMerge(destination, first, second, flags);

        public void HyperLogLogMerge(RedisKey destination, RedisKey[] sourceKeys, CommandFlags flags = CommandFlags.None)
            => _database.HyperLogLogMerge(destination, sourceKeys, flags);

        public Task HyperLogLogMergeAsync(RedisKey destination, RedisKey first, RedisKey second, CommandFlags flags = CommandFlags.None)
            => _database.HyperLogLogMergeAsync(destination, first, second, flags);

        public Task HyperLogLogMergeAsync(RedisKey destination, RedisKey[] sourceKeys, CommandFlags flags = CommandFlags.None)
            => _database.HyperLogLogMergeAsync(destination, sourceKeys, flags);

        public EndPoint IdentifyEndpoint(RedisKey key = default(RedisKey), CommandFlags flags = CommandFlags.None)
            => _database.IdentifyEndpoint(key, flags);

        public Task<EndPoint> IdentifyEndpointAsync(RedisKey key = default(RedisKey), CommandFlags flags = CommandFlags.None)
            => _database.IdentifyEndpointAsync(key, flags);

        public bool IsConnected(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.IsConnected(key, flags);

        public bool KeyDelete(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.KeyDelete(key, flags);

        public long KeyDelete(RedisKey[] keys, CommandFlags flags = CommandFlags.None)
            => _database.KeyDelete(keys, flags);

        public Task<bool> KeyDeleteAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.KeyDeleteAsync(key, flags);

        public Task<long> KeyDeleteAsync(RedisKey[] keys, CommandFlags flags = CommandFlags.None)
            => _database.KeyDeleteAsync(keys, flags);

        public byte[] KeyDump(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.KeyDump(key, flags);

        public Task<byte[]> KeyDumpAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.KeyDumpAsync(key, flags);

        public bool KeyExists(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.KeyExists(key, flags);

        public Task<bool> KeyExistsAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.KeyExistsAsync(key, flags);

        public bool KeyExpire(RedisKey key, TimeSpan? expiry, CommandFlags flags = CommandFlags.None)
            => _database.KeyExpire(key, expiry, flags);

        public bool KeyExpire(RedisKey key, DateTime? expiry, CommandFlags flags = CommandFlags.None)
            => _database.KeyExpire(key, expiry, flags);

        public Task<bool> KeyExpireAsync(RedisKey key, TimeSpan? expiry, CommandFlags flags = CommandFlags.None)
            => _database.KeyExpireAsync(key, expiry, flags);

        public Task<bool> KeyExpireAsync(RedisKey key, DateTime? expiry, CommandFlags flags = CommandFlags.None)
            => _database.KeyExpireAsync(key, expiry, flags);

        public void KeyMigrate(RedisKey key, EndPoint toServer, int toDatabase = 0, int timeoutMilliseconds = 0, MigrateOptions migrateOptions = MigrateOptions.None, CommandFlags flags = CommandFlags.None)
            => _database.KeyMigrate(key, toServer, toDatabase, timeoutMilliseconds, migrateOptions, flags);

        public Task KeyMigrateAsync(RedisKey key, EndPoint toServer, int toDatabase = 0, int timeoutMilliseconds = 0, MigrateOptions migrateOptions = MigrateOptions.None, CommandFlags flags = CommandFlags.None)
            => _database.KeyMigrateAsync(key, toServer, toDatabase, timeoutMilliseconds, migrateOptions, flags);

        public bool KeyMove(RedisKey key, int database, CommandFlags flags = CommandFlags.None)
            => this._database.KeyMove(key, database, flags);

        public Task<bool> KeyMoveAsync(RedisKey key, int database, CommandFlags flags = CommandFlags.None)
            => this._database.KeyMoveAsync(key, database, flags);

        public bool KeyPersist(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.KeyPersist(key, flags);

        public Task<bool> KeyPersistAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.KeyPersistAsync(key, flags);

        public RedisKey KeyRandom(CommandFlags flags = CommandFlags.None)
            => _database.KeyRandom(flags);

        public Task<RedisKey> KeyRandomAsync(CommandFlags flags = CommandFlags.None)
            => _database.KeyRandomAsync(flags);

        public bool KeyRename(RedisKey key, RedisKey newKey, When when = When.Always, CommandFlags flags = CommandFlags.None)
            => _database.KeyRename(key, newKey, when, flags);

        public Task<bool> KeyRenameAsync(RedisKey key, RedisKey newKey, When when = When.Always, CommandFlags flags = CommandFlags.None)
            => _database.KeyRenameAsync(key, newKey, when, flags);

        public void KeyRestore(RedisKey key, byte[] value, TimeSpan? expiry = null, CommandFlags flags = CommandFlags.None)
            => _database.KeyRestore(key, value, expiry, flags);

        public Task KeyRestoreAsync(RedisKey key, byte[] value, TimeSpan? expiry = null, CommandFlags flags = CommandFlags.None)
            => _database.KeyRestoreAsync(key, value, expiry);

        public TimeSpan? KeyTimeToLive(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.KeyTimeToLive(key, flags);

        public Task<TimeSpan?> KeyTimeToLiveAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.KeyTimeToLiveAsync(key, flags);

        public RedisType KeyType(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.KeyType(key, flags);

        public Task<RedisType> KeyTypeAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.KeyTypeAsync(key, flags);

        public RedisValue ListGetByIndex(RedisKey key, long index, CommandFlags flags = CommandFlags.None)
            => _database.ListGetByIndex(key, index, flags);

        public Task<RedisValue> ListGetByIndexAsync(RedisKey key, long index, CommandFlags flags = CommandFlags.None)
            => _database.ListGetByIndexAsync(key, index, flags);

        public long ListInsertAfter(RedisKey key, RedisValue pivot, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.ListInsertAfter(key, pivot, value, flags);

        public Task<long> ListInsertAfterAsync(RedisKey key, RedisValue pivot, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.ListInsertAfterAsync(key, pivot, value, flags);

        public long ListInsertBefore(RedisKey key, RedisValue pivot, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.ListInsertBefore(key, pivot, value, flags);

        public Task<long> ListInsertBeforeAsync(RedisKey key, RedisValue pivot, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.ListInsertBeforeAsync(key, pivot, value, flags);

        public RedisValue ListLeftPop(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.ListLeftPop(key, flags);

        public Task<RedisValue> ListLeftPopAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.ListLeftPopAsync(key, flags);

        public long ListLeftPush(RedisKey key, RedisValue value, When when = When.Always, CommandFlags flags = CommandFlags.None)
            => _database.ListLeftPush(key, value, when, flags);

        public long ListLeftPush(RedisKey key, RedisValue[] values, CommandFlags flags = CommandFlags.None)
            => _database.ListLeftPush(key, values, flags);

        public Task<long> ListLeftPushAsync(RedisKey key, RedisValue value, When when = When.Always, CommandFlags flags = CommandFlags.None)
            => _database.ListLeftPushAsync(key, value, when, flags);

        public Task<long> ListLeftPushAsync(RedisKey key, RedisValue[] values, CommandFlags flags = CommandFlags.None)
            => _database.ListLeftPushAsync(key, values, flags);

        public long ListLength(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.ListLength(key, flags);

        public Task<long> ListLengthAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.ListLengthAsync(key, flags);

        public RedisValue[] ListRange(RedisKey key, long start = 0, long stop = -1, CommandFlags flags = CommandFlags.None)
            => _database.ListRange(key, start, stop, flags);

        public Task<RedisValue[]> ListRangeAsync(RedisKey key, long start = 0, long stop = -1, CommandFlags flags = CommandFlags.None)
            => _database.ListRangeAsync(key, start, stop, flags);

        public long ListRemove(RedisKey key, RedisValue value, long count = 0, CommandFlags flags = CommandFlags.None)
            => _database.ListRemove(key, value, count, flags);

        public Task<long> ListRemoveAsync(RedisKey key, RedisValue value, long count = 0, CommandFlags flags = CommandFlags.None)
            => _database.ListRemoveAsync(key, value, count, flags);

        public RedisValue ListRightPop(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.ListRightPop(key, flags);

        public Task<RedisValue> ListRightPopAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.ListRightPopAsync(key, flags);

        public RedisValue ListRightPopLeftPush(RedisKey source, RedisKey destination, CommandFlags flags = CommandFlags.None)
            => _database.ListRightPopLeftPush(source, destination, flags);

        public Task<RedisValue> ListRightPopLeftPushAsync(RedisKey source, RedisKey destination, CommandFlags flags = CommandFlags.None)
            => _database.ListRightPopLeftPushAsync(source, destination, flags);

        public long ListRightPush(RedisKey key, RedisValue value, When when = When.Always, CommandFlags flags = CommandFlags.None)
            => _database.ListRightPush(key, value, when, flags);

        public long ListRightPush(RedisKey key, RedisValue[] values, CommandFlags flags = CommandFlags.None)
            => _database.ListRightPush(key, values, flags);

        public Task<long> ListRightPushAsync(RedisKey key, RedisValue value, When when = When.Always, CommandFlags flags = CommandFlags.None)
            => _database.ListRightPushAsync(key, value, when, flags);

        public Task<long> ListRightPushAsync(RedisKey key, RedisValue[] values, CommandFlags flags = CommandFlags.None)
            => _database.ListRightPushAsync(key, values, flags);

        public void ListSetByIndex(RedisKey key, long index, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.ListSetByIndex(key, index, value, flags);

        public Task ListSetByIndexAsync(RedisKey key, long index, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.ListSetByIndexAsync(key, index, value, flags);

        public void ListTrim(RedisKey key, long start, long stop, CommandFlags flags = CommandFlags.None)
            => _database.ListTrim(key, start, stop, flags);

        public Task ListTrimAsync(RedisKey key, long start, long stop, CommandFlags flags = CommandFlags.None)
            => _database.ListTrimAsync(key, start, stop, flags);

        public bool LockExtend(RedisKey key, RedisValue value, TimeSpan expiry, CommandFlags flags = CommandFlags.None)
            => _database.LockExtend(key, value, expiry, flags);

        public Task<bool> LockExtendAsync(RedisKey key, RedisValue value, TimeSpan expiry, CommandFlags flags = CommandFlags.None)
            => _database.LockExtendAsync(key, value, expiry, flags);

        public RedisValue LockQuery(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.LockQuery(key, flags);

        public Task<RedisValue> LockQueryAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.LockQueryAsync(key, flags);

        public bool LockRelease(RedisKey key, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.LockRelease(key, value, flags);

        public Task<bool> LockReleaseAsync(RedisKey key, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.LockReleaseAsync(key, value, flags);

        public bool LockTake(RedisKey key, RedisValue value, TimeSpan expiry, CommandFlags flags = CommandFlags.None)
            => _database.LockTake(key, value, expiry);

        public Task<bool> LockTakeAsync(RedisKey key, RedisValue value, TimeSpan expiry, CommandFlags flags = CommandFlags.None)
            => _database.LockTakeAsync(key, value, expiry, flags);

        public TimeSpan Ping(CommandFlags flags = CommandFlags.None)
            => _database.Ping(flags);

        public Task<TimeSpan> PingAsync(CommandFlags flags = CommandFlags.None)
            => _database.PingAsync(flags);

        public long Publish(RedisChannel channel, RedisValue message, CommandFlags flags = CommandFlags.None)
            => _database.Publish(channel, message, flags);

        public Task<long> PublishAsync(RedisChannel channel, RedisValue message, CommandFlags flags = CommandFlags.None)
            => _database.PublishAsync(channel, message, flags);

        public RedisResult ScriptEvaluate(string script, RedisKey[] keys = null, RedisValue[] values = null, CommandFlags flags = CommandFlags.None)
            => _database.ScriptEvaluate(script, keys, values, flags);

        public RedisResult ScriptEvaluate(byte[] hash, RedisKey[] keys = null, RedisValue[] values = null, CommandFlags flags = CommandFlags.None)
            => _database.ScriptEvaluate(hash, keys, values, flags);

        public RedisResult ScriptEvaluate(LuaScript script, object parameters = null, CommandFlags flags = CommandFlags.None)
            => _database.ScriptEvaluate(script, parameters, flags);

        public RedisResult ScriptEvaluate(LoadedLuaScript script, object parameters = null, CommandFlags flags = CommandFlags.None)
            => _database.ScriptEvaluate(script, parameters, flags);

        public Task<RedisResult> ScriptEvaluateAsync(string script, RedisKey[] keys = null, RedisValue[] values = null, CommandFlags flags = CommandFlags.None)
            => _database.ScriptEvaluateAsync(script, keys, values, flags);

        public Task<RedisResult> ScriptEvaluateAsync(byte[] hash, RedisKey[] keys = null, RedisValue[] values = null, CommandFlags flags = CommandFlags.None)
            => _database.ScriptEvaluateAsync(hash, keys, values, flags);

        public Task<RedisResult> ScriptEvaluateAsync(LuaScript script, object parameters = null, CommandFlags flags = CommandFlags.None)
            => _database.ScriptEvaluateAsync(script, parameters, flags);

        public Task<RedisResult> ScriptEvaluateAsync(LoadedLuaScript script, object parameters = null, CommandFlags flags = CommandFlags.None)
            => _database.ScriptEvaluateAsync(script, parameters, flags);

        public bool SetAdd(RedisKey key, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.SetAdd(key, value, flags);

        public long SetAdd(RedisKey key, RedisValue[] values, CommandFlags flags = CommandFlags.None)
            => _database.SetAdd(key, values, flags);

        public Task<bool> SetAddAsync(RedisKey key, RedisValue value, CommandFlags flags = CommandFlags.None)
            => SetAddAsync(key, value, flags);

        public Task<long> SetAddAsync(RedisKey key, RedisValue[] values, CommandFlags flags = CommandFlags.None)
            => _database.SetAddAsync(key, values, flags);

        public RedisValue[] SetCombine(SetOperation operation, RedisKey first, RedisKey second, CommandFlags flags = CommandFlags.None)
            => _database.SetCombine(operation, first, second, flags);

        public RedisValue[] SetCombine(SetOperation operation, RedisKey[] keys, CommandFlags flags = CommandFlags.None)
            => _database.SetCombine(operation, keys, flags);

        public long SetCombineAndStore(SetOperation operation, RedisKey destination, RedisKey first, RedisKey second, CommandFlags flags = CommandFlags.None)
            => _database.SetCombineAndStore(operation, destination, first, second, flags);

        public long SetCombineAndStore(SetOperation operation, RedisKey destination, RedisKey[] keys, CommandFlags flags = CommandFlags.None)
            => _database.SetCombineAndStore(operation, destination, keys, flags);

        public Task<long> SetCombineAndStoreAsync(SetOperation operation, RedisKey destination, RedisKey first, RedisKey second, CommandFlags flags = CommandFlags.None)
            => _database.SetCombineAndStoreAsync(operation, destination, first, second, flags);

        public Task<long> SetCombineAndStoreAsync(SetOperation operation, RedisKey destination, RedisKey[] keys, CommandFlags flags = CommandFlags.None)
            => _database.SetCombineAndStoreAsync(operation, destination, keys, flags);

        public Task<RedisValue[]> SetCombineAsync(SetOperation operation, RedisKey first, RedisKey second, CommandFlags flags = CommandFlags.None)
            => _database.SetCombineAsync(operation, first, second, flags);

        public Task<RedisValue[]> SetCombineAsync(SetOperation operation, RedisKey[] keys, CommandFlags flags = CommandFlags.None)
            => _database.SetCombineAsync(operation, keys, flags);

        public bool SetContains(RedisKey key, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.SetContains(key, value, flags);

        public Task<bool> SetContainsAsync(RedisKey key, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.SetContainsAsync(key, value, flags);

        public long SetLength(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.SetLength(key, flags);

        public Task<long> SetLengthAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.SetLengthAsync(key, flags);

        public RedisValue[] SetMembers(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.SetMembers(key, flags);

        public Task<RedisValue[]> SetMembersAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.SetMembersAsync(key, flags);

        public bool SetMove(RedisKey source, RedisKey destination, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.SetMove(source, destination, value, flags);

        public Task<bool> SetMoveAsync(RedisKey source, RedisKey destination, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.SetMoveAsync(source, destination, value, flags);

        public RedisValue SetPop(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.SetPop(key, flags);

        public Task<RedisValue> SetPopAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.SetPopAsync(key, flags);

        public RedisValue SetRandomMember(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.SetRandomMember(key, flags);

        public Task<RedisValue> SetRandomMemberAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.SetRandomMemberAsync(key, flags);

        public RedisValue[] SetRandomMembers(RedisKey key, long count, CommandFlags flags = CommandFlags.None)
            => _database.SetRandomMembers(key, count, flags);

        public Task<RedisValue[]> SetRandomMembersAsync(RedisKey key, long count, CommandFlags flags = CommandFlags.None)
            => _database.SetRandomMembersAsync(key, count, flags);

        public bool SetRemove(RedisKey key, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.SetRemove(key, value, flags);

        public long SetRemove(RedisKey key, RedisValue[] values, CommandFlags flags = CommandFlags.None)
            => _database.SetRemove(key, values, flags);

        public Task<bool> SetRemoveAsync(RedisKey key, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.SetRemoveAsync(key, value, flags);

        public Task<long> SetRemoveAsync(RedisKey key, RedisValue[] values, CommandFlags flags = CommandFlags.None)
            => _database.SetRemoveAsync(key, values, flags);

        public IEnumerable<RedisValue> SetScan(RedisKey key, RedisValue pattern, int pageSize, CommandFlags flags)
            => _database.SetScan(key, pattern, pageSize, flags);

        public IEnumerable<RedisValue> SetScan(RedisKey key, RedisValue pattern = default(RedisValue), int pageSize = 10, long cursor = 0, int pageOffset = 0, CommandFlags flags = CommandFlags.None)
            => _database.SetScan(key, pattern, pageSize, cursor, pageOffset, flags);

        public RedisValue[] Sort(RedisKey key, long skip = 0, long take = -1, Order order = Order.Ascending, SortType sortType = SortType.Numeric, RedisValue by = default(RedisValue), RedisValue[] get = null, CommandFlags flags = CommandFlags.None)
            => _database.Sort(key, skip, take, order, sortType, by, get, flags);

        public long SortAndStore(RedisKey destination, RedisKey key, long skip = 0, long take = -1, Order order = Order.Ascending, SortType sortType = SortType.Numeric, RedisValue by = default(RedisValue), RedisValue[] get = null, CommandFlags flags = CommandFlags.None)
            => _database.SortAndStore(destination, key, skip, take, order, sortType, by, get, flags);

        public Task<long> SortAndStoreAsync(RedisKey destination, RedisKey key, long skip = 0, long take = -1, Order order = Order.Ascending, SortType sortType = SortType.Numeric, RedisValue by = default(RedisValue), RedisValue[] get = null, CommandFlags flags = CommandFlags.None)
            => _database.SortAndStoreAsync(destination, key, skip, take, order, sortType, by, get, flags);

        public Task<RedisValue[]> SortAsync(RedisKey key, long skip = 0, long take = -1, Order order = Order.Ascending, SortType sortType = SortType.Numeric, RedisValue by = default(RedisValue), RedisValue[] get = null, CommandFlags flags = CommandFlags.None)
            => _database.SortAsync(key, skip, take, order, sortType, by, get, flags);

        public bool SortedSetAdd(RedisKey key, RedisValue member, double score, CommandFlags flags)
            => _database.SortedSetAdd(key, member, score, flags);

        public bool SortedSetAdd(RedisKey key, RedisValue member, double score, When when = When.Always, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetAdd(key, member, score, when, flags);

        public long SortedSetAdd(RedisKey key, SortedSetEntry[] values, CommandFlags flags)
            => _database.SortedSetAdd(key, values, flags);

        public long SortedSetAdd(RedisKey key, SortedSetEntry[] values, When when = When.Always, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetAdd(key, values, when, flags);

        public Task<bool> SortedSetAddAsync(RedisKey key, RedisValue member, double score, CommandFlags flags)
            => _database.SortedSetAddAsync(key, member, score, flags);

        public Task<bool> SortedSetAddAsync(RedisKey key, RedisValue member, double score, When when = When.Always, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetAddAsync(key, member, score, when, flags);

        public Task<long> SortedSetAddAsync(RedisKey key, SortedSetEntry[] values, CommandFlags flags)
            => _database.SortedSetAddAsync(key, values, flags);

        public Task<long> SortedSetAddAsync(RedisKey key, SortedSetEntry[] values, When when = When.Always, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetAddAsync(key, values, when, flags);

        public long SortedSetCombineAndStore(SetOperation operation, RedisKey destination, RedisKey first, RedisKey second, Aggregate aggregate = Aggregate.Sum, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetCombineAndStore(operation, destination, first, second, aggregate, flags);

        public long SortedSetCombineAndStore(SetOperation operation, RedisKey destination, RedisKey[] keys, double[] weights = null, Aggregate aggregate = Aggregate.Sum, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetCombineAndStore(operation, destination, keys, weights, aggregate, flags);

        public Task<long> SortedSetCombineAndStoreAsync(SetOperation operation, RedisKey destination, RedisKey first, RedisKey second, Aggregate aggregate = Aggregate.Sum, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetCombineAndStoreAsync(operation, destination, first, second, aggregate, flags);

        public Task<long> SortedSetCombineAndStoreAsync(SetOperation operation, RedisKey destination, RedisKey[] keys, double[] weights = null, Aggregate aggregate = Aggregate.Sum, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetCombineAndStoreAsync(operation, destination, keys, weights, aggregate, flags);

        public double SortedSetDecrement(RedisKey key, RedisValue member, double value, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetDecrement(key, member, value, flags);

        public Task<double> SortedSetDecrementAsync(RedisKey key, RedisValue member, double value, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetDecrementAsync(key, member, value, flags);

        public double SortedSetIncrement(RedisKey key, RedisValue member, double value, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetIncrement(key, member, value, flags);

        public Task<double> SortedSetIncrementAsync(RedisKey key, RedisValue member, double value, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetIncrementAsync(key, member, value, flags);

        public long SortedSetLength(RedisKey key, double min = double.NegativeInfinity, double max = double.PositiveInfinity, Exclude exclude = Exclude.None, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetLength(key, min, min, exclude, flags);

        public Task<long> SortedSetLengthAsync(RedisKey key, double min = double.NegativeInfinity, double max = double.PositiveInfinity, Exclude exclude = Exclude.None, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetLengthAsync(key, min, max, exclude, flags);

        public long SortedSetLengthByValue(RedisKey key, RedisValue min, RedisValue max, Exclude exclude = Exclude.None, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetLengthByValue(key, min, max, exclude, flags);

        public Task<long> SortedSetLengthByValueAsync(RedisKey key, RedisValue min, RedisValue max, Exclude exclude = Exclude.None, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetLengthByValueAsync(key, min, max, exclude, flags);

        public RedisValue[] SortedSetRangeByRank(RedisKey key, long start = 0, long stop = -1, Order order = Order.Ascending, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRangeByRank(key, start, stop, order, flags);

        public Task<RedisValue[]> SortedSetRangeByRankAsync(RedisKey key, long start = 0, long stop = -1, Order order = Order.Ascending, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRangeByRankAsync(key, start, stop, order, flags);

        public SortedSetEntry[] SortedSetRangeByRankWithScores(RedisKey key, long start = 0, long stop = -1, Order order = Order.Ascending, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRangeByRankWithScores(key, stop, stop, order, flags);

        public Task<SortedSetEntry[]> SortedSetRangeByRankWithScoresAsync(RedisKey key, long start = 0, long stop = -1, Order order = Order.Ascending, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRangeByRankWithScoresAsync(key, start, stop, order, flags);

        public RedisValue[] SortedSetRangeByScore(RedisKey key, double start = double.NegativeInfinity, double stop = double.PositiveInfinity, Exclude exclude = Exclude.None, Order order = Order.Ascending, long skip = 0, long take = -1, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRangeByScore(key, start, stop, exclude, order, skip, take, flags);

        public Task<RedisValue[]> SortedSetRangeByScoreAsync(RedisKey key, double start = double.NegativeInfinity, double stop = double.PositiveInfinity, Exclude exclude = Exclude.None, Order order = Order.Ascending, long skip = 0, long take = -1, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRangeByScoreAsync(key, start, stop, exclude, order, skip, take, flags);

        public SortedSetEntry[] SortedSetRangeByScoreWithScores(RedisKey key, double start = double.NegativeInfinity, double stop = double.PositiveInfinity, Exclude exclude = Exclude.None, Order order = Order.Ascending, long skip = 0, long take = -1, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRangeByScoreWithScores(key, start, stop, exclude, order, skip, take, flags);

        public Task<SortedSetEntry[]> SortedSetRangeByScoreWithScoresAsync(RedisKey key, double start = double.NegativeInfinity, double stop = double.PositiveInfinity, Exclude exclude = Exclude.None, Order order = Order.Ascending, long skip = 0, long take = -1, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRangeByScoreWithScoresAsync(key, start, stop, exclude, order, skip, take, flags);

        public RedisValue[] SortedSetRangeByValue(RedisKey key, RedisValue min = default(RedisValue), RedisValue max = default(RedisValue), Exclude exclude = Exclude.None, long skip = 0, long take = -1, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRangeByValue(key, min, max, exclude, skip, take, flags);

        public Task<RedisValue[]> SortedSetRangeByValueAsync(RedisKey key, RedisValue min = default(RedisValue), RedisValue max = default(RedisValue), Exclude exclude = Exclude.None, long skip = 0, long take = -1, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRangeByValueAsync(key, min, max, exclude, skip, take, flags);

        public long? SortedSetRank(RedisKey key, RedisValue member, Order order = Order.Ascending, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRank(key, member, order, flags);

        public Task<long?> SortedSetRankAsync(RedisKey key, RedisValue member, Order order = Order.Ascending, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRankAsync(key, member, order, flags);

        public bool SortedSetRemove(RedisKey key, RedisValue member, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRemove(key, member, flags);

        public long SortedSetRemove(RedisKey key, RedisValue[] members, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRemove(key, members, flags);

        public Task<bool> SortedSetRemoveAsync(RedisKey key, RedisValue member, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRemoveAsync(key, member, flags);

        public Task<long> SortedSetRemoveAsync(RedisKey key, RedisValue[] members, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRemoveAsync(key, members, flags);

        public long SortedSetRemoveRangeByRank(RedisKey key, long start, long stop, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRemoveRangeByRank(key, start, stop, flags);

        public Task<long> SortedSetRemoveRangeByRankAsync(RedisKey key, long start, long stop, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRemoveRangeByRankAsync(key, start, stop, flags);

        public long SortedSetRemoveRangeByScore(RedisKey key, double start, double stop, Exclude exclude = Exclude.None, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRemoveRangeByScore(key, start, stop, exclude, flags);

        public Task<long> SortedSetRemoveRangeByScoreAsync(RedisKey key, double start, double stop, Exclude exclude = Exclude.None, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRemoveRangeByScoreAsync(key, start, stop, exclude, flags);

        public long SortedSetRemoveRangeByValue(RedisKey key, RedisValue min, RedisValue max, Exclude exclude = Exclude.None, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRemoveRangeByValue(key, min, max, exclude, flags);

        public Task<long> SortedSetRemoveRangeByValueAsync(RedisKey key, RedisValue min, RedisValue max, Exclude exclude = Exclude.None, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetRemoveRangeByValueAsync(key, min, max, exclude, flags);

        public IEnumerable<SortedSetEntry> SortedSetScan(RedisKey key, RedisValue pattern, int pageSize, CommandFlags flags)
            => _database.SortedSetScan(key, pattern, pageSize, flags);
        public IEnumerable<SortedSetEntry> SortedSetScan(RedisKey key, RedisValue pattern = default(RedisValue), int pageSize = 10, long cursor = 0, int pageOffset = 0, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetScan(key, pattern, pageSize, cursor, pageOffset, flags);

        public double? SortedSetScore(RedisKey key, RedisValue member, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetScore(key, member, flags);

        public Task<double?> SortedSetScoreAsync(RedisKey key, RedisValue member, CommandFlags flags = CommandFlags.None)
            => _database.SortedSetScoreAsync(key, member, flags);

        public long StringAppend(RedisKey key, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.StringAppend(key, value, flags);

        public Task<long> StringAppendAsync(RedisKey key, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.StringAppendAsync(key, value, flags);

        public long StringBitCount(RedisKey key, long start = 0, long end = -1, CommandFlags flags = CommandFlags.None)
            => _database.StringBitCount(key, start, end, flags);

        public Task<long> StringBitCountAsync(RedisKey key, long start = 0, long end = -1, CommandFlags flags = CommandFlags.None)
            => _database.StringBitCountAsync(key, start, end, flags);

        public long StringBitOperation(Bitwise operation, RedisKey destination, RedisKey first, RedisKey second = default(RedisKey), CommandFlags flags = CommandFlags.None)
            => _database.StringBitOperation(operation, destination, first, second, flags);

        public long StringBitOperation(Bitwise operation, RedisKey destination, RedisKey[] keys, CommandFlags flags = CommandFlags.None)
            => _database.StringBitOperation(operation, destination, keys, flags);

        public Task<long> StringBitOperationAsync(Bitwise operation, RedisKey destination, RedisKey first, RedisKey second = default(RedisKey), CommandFlags flags = CommandFlags.None)
            => _database.StringBitOperationAsync(operation, destination, first, second, flags);

        public Task<long> StringBitOperationAsync(Bitwise operation, RedisKey destination, RedisKey[] keys, CommandFlags flags = CommandFlags.None)
            => _database.StringBitOperationAsync(operation, destination, keys, flags);

        public long StringBitPosition(RedisKey key, bool bit, long start = 0, long end = -1, CommandFlags flags = CommandFlags.None)
            => _database.StringBitPosition(key, bit, start, end, flags);

        public Task<long> StringBitPositionAsync(RedisKey key, bool bit, long start = 0, long end = -1, CommandFlags flags = CommandFlags.None)
            => _database.StringBitPositionAsync(key, bit, start, end, flags);

        public long StringDecrement(RedisKey key, long value = 1, CommandFlags flags = CommandFlags.None)
            => _database.StringDecrement(key, value, flags);

        public double StringDecrement(RedisKey key, double value, CommandFlags flags = CommandFlags.None)
            => _database.StringDecrement(key, value, flags);

        public Task<long> StringDecrementAsync(RedisKey key, long value = 1, CommandFlags flags = CommandFlags.None)
            => _database.StringDecrementAsync(key, value, flags);

        public Task<double> StringDecrementAsync(RedisKey key, double value, CommandFlags flags = CommandFlags.None)
            => _database.StringDecrementAsync(key, value, flags);

        public RedisValue StringGet(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.StringGet(key, flags);

        public RedisValue[] StringGet(RedisKey[] keys, CommandFlags flags = CommandFlags.None)
            => _database.StringGet(keys, flags);

        public Task<RedisValue> StringGetAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.StringGetAsync(key, flags);

        public Task<RedisValue[]> StringGetAsync(RedisKey[] keys, CommandFlags flags = CommandFlags.None)
            => _database.StringGetAsync(keys, flags);

        public bool StringGetBit(RedisKey key, long offset, CommandFlags flags = CommandFlags.None)
            => _database.StringGetBit(key, offset, flags);

        public Task<bool> StringGetBitAsync(RedisKey key, long offset, CommandFlags flags = CommandFlags.None)
            => _database.StringGetBitAsync(key, offset, flags);

        public RedisValue StringGetRange(RedisKey key, long start, long end, CommandFlags flags = CommandFlags.None)
            => _database.StringGetRange(key, start, end, flags);

        public Task<RedisValue> StringGetRangeAsync(RedisKey key, long start, long end, CommandFlags flags = CommandFlags.None)
            => _database.StringGetRangeAsync(key, start, end, flags);

        public RedisValue StringGetSet(RedisKey key, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.StringGetSet(key, value, flags);

        public Task<RedisValue> StringGetSetAsync(RedisKey key, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.StringGetSetAsync(key, value, flags);

        public RedisValueWithExpiry StringGetWithExpiry(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.StringGetWithExpiry(key, flags);

        public Task<RedisValueWithExpiry> StringGetWithExpiryAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.StringGetWithExpiryAsync(key, flags);

        public long StringIncrement(RedisKey key, long value = 1, CommandFlags flags = CommandFlags.None)
            => _database.StringIncrement(key, value, flags);

        public double StringIncrement(RedisKey key, double value, CommandFlags flags = CommandFlags.None)
            => _database.StringIncrement(key, value, flags);

        public Task<long> StringIncrementAsync(RedisKey key, long value = 1, CommandFlags flags = CommandFlags.None)
            => _database.StringIncrementAsync(key, value, flags);

        public Task<double> StringIncrementAsync(RedisKey key, double value, CommandFlags flags = CommandFlags.None)
            => _database.StringIncrementAsync(key, value, flags);

        public long StringLength(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.StringLength(key, flags);

        public Task<long> StringLengthAsync(RedisKey key, CommandFlags flags = CommandFlags.None)
            => _database.StringLengthAsync(key, flags);

        public bool StringSet(RedisKey key, RedisValue value, TimeSpan? expiry = null, When when = When.Always, CommandFlags flags = CommandFlags.None)
            => _database.StringSet(key, value, expiry, when, flags);

        public bool StringSet(KeyValuePair<RedisKey, RedisValue>[] values, When when = When.Always, CommandFlags flags = CommandFlags.None)
            => _database.StringSet(values, when, flags);

        public Task<bool> StringSetAsync(RedisKey key, RedisValue value, TimeSpan? expiry = null, When when = When.Always, CommandFlags flags = CommandFlags.None)
            => _database.StringSetAsync(key, value, expiry, when, flags);

        public Task<bool> StringSetAsync(KeyValuePair<RedisKey, RedisValue>[] values, When when = When.Always, CommandFlags flags = CommandFlags.None)
            => _database.StringSetAsync(values, when, flags);

        public bool StringSetBit(RedisKey key, long offset, bool bit, CommandFlags flags = CommandFlags.None)
            => _database.StringSetBit(key, offset, bit, flags);

        public Task<bool> StringSetBitAsync(RedisKey key, long offset, bool bit, CommandFlags flags = CommandFlags.None)
            => _database.StringSetBitAsync(key, offset, bit, flags);

        public RedisValue StringSetRange(RedisKey key, long offset, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.StringSetRange(key, offset, value, flags);

        public Task<RedisValue> StringSetRangeAsync(RedisKey key, long offset, RedisValue value, CommandFlags flags = CommandFlags.None)
            => _database.StringSetRangeAsync(key, offset, value, flags);

        public bool TryWait(Task task)
            => _database.TryWait(task);

        public void Wait(Task task)
            => _database.Wait(task);

        public T Wait<T>(Task<T> task)
            => _database.Wait(task);

        public void WaitAll(params Task[] tasks)
            => _database.WaitAll(tasks);
    }
}
