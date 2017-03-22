using System.Web;
using Logs.Providers.Contracts;
using Moq;
using NUnit.Framework;

namespace Logs.Providers.Tests.CachingProviderTests
{
    [TestFixture]
    public class GetItemTests
    {
        [TestCase("key")]
        [TestCase("cachekey")]
        public void TestGetItem_ShouldCallHttpContextProviderCurrentCache(string key)
        {
            // Arrange
            var cache = HttpRuntime.Cache;

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.ContextCache).Returns(cache);

            var provider = new CachingProvider(mockedHttpContextProvider.Object);

            // Act
            provider.GetItem(key);

            // Assert
            mockedHttpContextProvider.Verify(p => p.ContextCache, Times.Once);
        }

        [TestCase("key")]
        [TestCase("cachekey")]
        public void TestGetItem_ShouldReturnCorrectly(string key)
        {
            // Arrange
            var obj = new object();

            var cache = HttpRuntime.Cache;
            cache[key] = obj;

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.ContextCache).Returns(cache);

            var provider = new CachingProvider(mockedHttpContextProvider.Object);

            // Act
            var result = provider.GetItem(key);

            // Assert
            Assert.AreSame(obj, result);
        }
    }
}
