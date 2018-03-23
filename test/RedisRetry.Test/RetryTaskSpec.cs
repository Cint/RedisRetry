using System;
using System.Threading.Tasks;
using Moq;
using Shouldly;
using StackExchange.Redis;
using Xunit;

namespace RedisRetry.Test
{
    public class RetryTaskSpec
    {
        private static readonly Func<int, TimeSpan> noWaitProvider =
            retryAttempt => TimeSpan.FromSeconds(0);

        private int _callbackCounter = 0;

        private async Task FailingTask(int timesToFail, Exception exception)
        {
            await Mock.Of<IDatabase>().StringSetAsync("test", "test");
            _callbackCounter++;
            if (_callbackCounter <= timesToFail) throw exception;
        }

        [Fact]
        public async Task RetryTask_works_with_no_exceptions()
        {
            var task = new RetryTask(() => FailingTask(0, new TimeoutException()));
            await task.RunAsync();
            _callbackCounter.ShouldBe(1);
        }

        [Fact]
        public async Task RetryTask_works_with_exception()
        {
            var task = new RetryTask(() => FailingTask(1, new TimeoutException()), 3, noWaitProvider);
            await task.RunAsync();
            _callbackCounter.ShouldBe(2);
        }

        [Fact]
        public async Task RetryTask_fails_after_four_exceptions()
        {
            var task = new RetryTask(() => FailingTask(4, new TimeoutException()), 3, noWaitProvider);
            await task.RunAsync().ShouldThrowAsync<TimeoutException>();
            _callbackCounter.ShouldBe(4);
        }

        [Fact]
        public async Task RetryTask_does_not_retry_non_transient_exceptions()
        {
            var task = new RetryTask(() => FailingTask(4, new ArgumentNullException()), 3, noWaitProvider);
            await task.RunAsync().ShouldThrowAsync<ArgumentNullException>();
            _callbackCounter.ShouldBe(1);
        }
    }
}
