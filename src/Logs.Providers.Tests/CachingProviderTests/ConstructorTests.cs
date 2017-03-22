using System;
using Logs.Providers.Contracts;
using Moq;
using NUnit.Framework;

namespace Logs.Providers.Tests.CachingProviderTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_PassEverything_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();

            // Act
            var provider = new CachingProvider(mockedHttpContextProvider.Object);

            // Assert
            Assert.IsNotNull(provider);
        }

        [Test]
        public void TestConstructor_ShouldBeInstanceOfICachingProvider()
        {
            // Arrange
            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();

            // Act
            var provider = new CachingProvider(mockedHttpContextProvider.Object);

            // Assert
            Assert.IsInstanceOf<ICachingProvider>(provider);
        }

        [Test]
        public void TestConstructor_PassHttpContextProviderNull_ShouldThrowArgumentNullException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new CachingProvider(null));
        }
    }
}
