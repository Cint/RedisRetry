using System.Collections.Generic;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace RedisRetry
{
    public static class RedisTransactionExtension
    {
        public static Task<bool> ExecuteAsyncWithRetries(this ITransaction transaction, CommandFlags flags = CommandFlags.None, int retryCount = 3)
        {
            return new RedisRetryTask<bool>(() => transaction.ExecuteAsync(flags), retryCount).RunAsync();
        }

        public static Task<RedisResult> ExecuteAsyncWithRetries(this ITransaction transaction, string command, ICollection<object> args, CommandFlags flags = CommandFlags.None, int retryCount = 3)
        {
            return new RedisRetryTask<RedisResult>(() => transaction.ExecuteAsync(command, args, flags), retryCount).RunAsync();
        }
    }
}
