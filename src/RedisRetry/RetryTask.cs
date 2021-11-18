using System;
using Polly;
using System.Threading.Tasks;
using StackExchange.Redis;
using Polly.Retry;

namespace RedisRetry
{
    public class RetryTask
    {
        private readonly Func<Task> _func;
        private static readonly Func<int, TimeSpan> RetryAttemptWaitProvider =
            retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));

        private AsyncRetryPolicy _retryPolicy;

        public RetryTask(Func<Task> func, int retryCount = 3, Func<int, TimeSpan> waitProvider = null)
        {
            _func = func;
            _retryPolicy = Policy
               .Handle<RedisServerException>()
               .Or<RedisConnectionException>()
               .Or<TimeoutException>()
               .WaitAndRetryAsync(retryCount, waitProvider ?? RetryAttemptWaitProvider);
        }

        public async Task RunAsync()
        {
            await _retryPolicy.ExecuteAsync(_func)
                .ConfigureAwait(false);
        }
    }
}
