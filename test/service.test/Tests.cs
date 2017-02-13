using FakeItEasy;
using Microsoft.Extensions.Logging;
using Xunit;

namespace SampleNancy.Test
{
    public class ServiceTests
    {
        [Fact]
        public void Test1() 
        {
            var logger = A.Fake<ILoggerFactory>();
            var service = new Service(logger);
            Assert.NotNull(service);
        }
    }
}
