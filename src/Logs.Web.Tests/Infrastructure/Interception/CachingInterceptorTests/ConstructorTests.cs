using System;
using Logs.Providers.Contracts;
using Logs.Web.Infrastructure.Interception;
using Moq;
using Ninject.Extensions.Interception;
using NUnit.Framework;

namespace Logs.Web.Tests.Infrastructure.Interception.CachingInterceptorTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverything_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedCachingProvider = new Mock<ICachingProvider>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            // Act
            var interceptor = new CachingInterceptor(mockedCachingProvider.Object, mockedDateTimeProvider.Object);

            // Assert
            Assert.IsNotNull(interceptor);
        }

        [Test]
        public void TestConstructor_ShouldBeInstanceOfIInterceptor()
        {
            // Arrange
            var mockedCachingProvider = new Mock<ICachingProvider>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            // Act
            var interceptor = new CachingInterceptor(mockedCachingProvider.Object, mockedDateTimeProvider.Object);

            // Assert
            Assert.IsInstanceOf<IInterceptor>(interceptor);
        }

        [Test]
        public void TestConstructor_PassCachingProviderNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            // Act
            Assert.Throws<ArgumentNullException>(() => 
                new CachingInterceptor(null, mockedDateTimeProvider.Object));
        }

        [Test]
        public void TestConstructor_PassDateTimeProviderNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedCachingProvider = new Mock<ICachingProvider>();

            // Act
            Assert.Throws<ArgumentNullException>(() =>
                new CachingInterceptor(mockedCachingProvider.Object, null));
        }
    }
}
