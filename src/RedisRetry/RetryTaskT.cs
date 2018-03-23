using System;
using Polly;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace RedisRetry
{
    public class RedisRetryTask<T>
    {
        private readonly Func<Task<T>> _func;
        private static readonly Func<int, TimeSpan> RetryAttemptWaitProvider =
            retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));

        private Policy _retryPolicy;

        public RedisRetryTask(Func<Task<T>> func, int retryCount = 3, Func<int, TimeSpan> waitProvider = null)
        {
            _func = func;
            _retryPolicy = Policy
               .Handle<RedisServerException>()
               .Or<RedisConnectionException>()
               .Or<TimeoutException>()
               .WaitAndRetryAsync(retryCount, waitProvider ?? RetryAttemptWaitProvider);
        }

        public async Task<T> RunAsync()
        {
            return await _retryPolicy.ExecuteAsync(_func)
                .ConfigureAwait(false);
        }
    }
}
