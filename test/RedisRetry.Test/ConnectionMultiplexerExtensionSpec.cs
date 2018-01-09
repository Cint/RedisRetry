using Moq;
using StackExchange.Redis;
using Xunit;

namespace RedisRetry.Test
{
    public class ConnectionMultiplexerExtensionSpec
    {
        [Fact]
        public void GetRetryDatabase()
        {
            var multiplexer = new Mock<IConnectionMultiplexer>();
            multiplexer.Setup(m => m.GetDatabase(It.IsAny<int>(), It.IsAny<object>())).Returns(Mock.Of<IDatabase>());
            var db = 8;
            var asyncState = new object();
            var database = IConnectionMultiplexerExtension.GetRetryDatabase(multiplexer.Object, db, asyncState);

            multiplexer.Verify(m => m.GetDatabase(db, asyncState));
        }
    }
}
