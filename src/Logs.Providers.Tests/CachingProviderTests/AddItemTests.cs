using System;
using System.Web;
using Logs.Providers.Contracts;
using Moq;
using NUnit.Framework;

namespace Logs.Providers.Tests.CachingProviderTests
{
    [TestFixture]
    public class AddItemTests
    {
        [TestCase("key")]
        [TestCase("cachekey")]
        public void TestAddItem_ShouldCallHttpContextProviderCurrentHttpContext(string key)
        {
            // Arrange
            var cache = HttpRuntime.Cache;

            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();
            mockedHttpContextProvider.Setup(p => p.ContextCache).Returns(cache);

            var provider = new CachingProvider(mockedHttpContextProvider.Object);

            // Act
            provider.AddItem(key, new object(), new DateTime());

            // Assert
            mockedHttpContextProvider.Verify(p => p.ContextCache, Times.Once);
        }
    }
}
