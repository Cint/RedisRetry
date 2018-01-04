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

        private async Task<int> FailingTask(int timesToFail)
        {
            await Mock.Of<IDatabase>().StringSetAsync("test", "test");
            _callbackCounter++;
            if (_callbackCounter <= timesToFail) throw new Exception();
            return _callbackCounter;
        }

        [Fact]
        public async Task RetryTask_works_with_no_exceptions()
        {
            var task = new RetryTask<int>(() => FailingTask(0));
            var result = await task.RunAsync();
            _callbackCounter.ShouldBe(1);
            result.ShouldBe(1);
        }

        [Fact]
        public async Task RetryTask_works_with_exception()
        {
            var task = new RetryTask<int>(() => FailingTask(1), 3, noWaitProvider);
            var result = await task.RunAsync();
            _callbackCounter.ShouldBe(2);
            result.ShouldBe(2);
        }

        [Fact]
        public async Task RetryTask_fails_after_four_exceptions()
        {
            var task = new RetryTask<int>(() => FailingTask(4), 3, noWaitProvider);
            await task.RunAsync().ShouldThrowAsync<Exception>();
            _callbackCounter.ShouldBe(4);
        }
    }
}
