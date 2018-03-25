using Moq;
using StackExchange.Redis;
using System.Collections.Generic;
using Xunit;

namespace RedisRetry.Test
{
    public class RedisTransactionExtensionSpec
    {
        private Mock<ITransaction> transaction = new Mock<ITransaction>();
        private int retryCount = 5;
        private string command = "--bigkeys";
        private ICollection<object> args = new List<object>() { new { foo = "bar" } };
        private CommandFlags flags = CommandFlags.NoRedirect;

        [Fact]
        public void ExecuteAsyncWithRetries()
        {
            RedisTransactionExtension.ExecuteAsyncWithRetries(transaction.Object);
            transaction.Verify(d => d.ExecuteAsync(CommandFlags.None), Times.Once);

            RedisTransactionExtension.ExecuteAsyncWithRetries(transaction.Object, flags);
            transaction.Verify(d => d.ExecuteAsync(flags), Times.Once);

            RedisTransactionExtension.ExecuteAsyncWithRetries(transaction.Object, command, args, flags, retryCount);
            transaction.Verify(d => d.ExecuteAsync(command, args, flags), Times.Once);
        }
    }
}
