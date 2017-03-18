using System;
using Logs.Providers.Contracts;
using Moq;
using NUnit.Framework;

namespace Logs.Authentication.Tests.AuthenticationProviderTests
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void TestConstructor_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();

            // Act
            var provider = new AuthenticationProvider(mockedDateTimeProvider.Object, mockedHttpContextProvider.Object);

            // Assert
            Assert.IsNotNull(provider);
        }

        [Test]
        public void TestConstructor_PassDateTimeProviderNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedHttpContextProvider = new Mock<IHttpContextProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new AuthenticationProvider(null, mockedHttpContextProvider.Object));
        }

        [Test]
        public void TestConstructor_PassHttpContextProviderNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() =>
                new AuthenticationProvider(mockedDateTimeProvider.Object, null));
        }
    }
}
