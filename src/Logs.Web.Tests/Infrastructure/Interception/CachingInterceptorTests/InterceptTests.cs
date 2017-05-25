using System;
using System.Reflection;
using Logs.Common;
using Logs.Providers.Contracts;
using Logs.Web.Infrastructure.Interception;
using Moq;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Request;
using NUnit.Framework;

namespace Logs.Web.Tests.Infrastructure.Interception.CachingInterceptorTests
{
    [TestFixture]
    public class InterceptTests
    {
        [Test]
        public void TestIntercept_ShouldCallInvocationRequestMethodName()
        {
            // Arrange
            var mockedCachingProvider = new Mock<ICachingProvider>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var interceptor = new CachingInterceptor(mockedCachingProvider.Object, mockedDateTimeProvider.Object);

            var mockedMethodInfo = new Mock<MethodInfo>();

            var mockedRequest = new Mock<IProxyRequest>();
            mockedRequest.Setup(r => r.Method).Returns(mockedMethodInfo.Object);

            var mockedInvocation = new Mock<IInvocation>();
            mockedInvocation.Setup(i => i.Request).Returns(mockedRequest.Object);

            // Act
            interceptor.Intercept(mockedInvocation.Object);

            // Assert
            mockedMethodInfo.Verify(m => m.Name, Times.Once);
        }

        [Test]
        public void TestIntercept_ShouldCallInvocationRequestArguments()
        {
            // Arrange
            var mockedCachingProvider = new Mock<ICachingProvider>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var interceptor = new CachingInterceptor(mockedCachingProvider.Object, mockedDateTimeProvider.Object);

            var mockedMethodInfo = new Mock<MethodInfo>();

            var mockedRequest = new Mock<IProxyRequest>();
            mockedRequest.Setup(r => r.Method).Returns(mockedMethodInfo.Object);

            var mockedInvocation = new Mock<IInvocation>();
            mockedInvocation.Setup(i => i.Request).Returns(mockedRequest.Object);

            // Act
            interceptor.Intercept(mockedInvocation.Object);

            // Assert
            mockedRequest.Verify(m => m.Arguments, Times.Once);
        }

        [TestCase("MyAwesomeMethod")]
        [TestCase("DoSomething")]
        public void TestIntercept_ShouldCallCachingProviderGetItem(string methodName)
        {
            // Arrange
            var mockedCachingProvider = new Mock<ICachingProvider>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var interceptor = new CachingInterceptor(mockedCachingProvider.Object, mockedDateTimeProvider.Object);

            var mockedMethodInfo = new Mock<MethodInfo>();
            mockedMethodInfo.Setup(m => m.Name).Returns(methodName);

            var mockedRequest = new Mock<IProxyRequest>();
            mockedRequest.Setup(r => r.Method).Returns(mockedMethodInfo.Object);

            var mockedInvocation = new Mock<IInvocation>();
            mockedInvocation.Setup(i => i.Request).Returns(mockedRequest.Object);

            // Act
            interceptor.Intercept(mockedInvocation.Object);

            // Assert
            mockedCachingProvider.Verify(p => p.GetItem(methodName), Times.Once);
        }

        [Test]
        public void TestIntercept_CachingProviderReturnsResult_ShouldSetInvocationReturnValue()
        {
            // Arrange
            var obj = new object();

            var mockedCachingProvider = new Mock<ICachingProvider>();
            mockedCachingProvider.Setup(p => p.GetItem(It.IsAny<string>())).Returns(obj);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var interceptor = new CachingInterceptor(mockedCachingProvider.Object, mockedDateTimeProvider.Object);

            var mockedMethodInfo = new Mock<MethodInfo>();

            var mockedRequest = new Mock<IProxyRequest>();
            mockedRequest.Setup(r => r.Method).Returns(mockedMethodInfo.Object);

            var mockedInvocation = new Mock<IInvocation>();
            mockedInvocation.Setup(i => i.Request).Returns(mockedRequest.Object);

            // Act
            interceptor.Intercept(mockedInvocation.Object);

            // Assert
            mockedInvocation.VerifySet(i => i.ReturnValue = obj, Times.Once);
        }

        [Test]
        public void TestIntercept_CachingProviderReturnsResult_ShouldNotCallInvocationProceed()
        {
            // Arrange
            var obj = new object();

            var mockedCachingProvider = new Mock<ICachingProvider>();
            mockedCachingProvider.Setup(p => p.GetItem(It.IsAny<string>())).Returns(obj);

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var interceptor = new CachingInterceptor(mockedCachingProvider.Object, mockedDateTimeProvider.Object);

            var mockedMethodInfo = new Mock<MethodInfo>();

            var mockedRequest = new Mock<IProxyRequest>();
            mockedRequest.Setup(r => r.Method).Returns(mockedMethodInfo.Object);

            var mockedInvocation = new Mock<IInvocation>();
            mockedInvocation.Setup(i => i.Request).Returns(mockedRequest.Object);

            // Act
            interceptor.Intercept(mockedInvocation.Object);

            // Assert
            mockedInvocation.Verify(i => i.Proceed(), Times.Never);
        }

        [Test]
        public void TestIntercept_CachingProviderDoesNotReturnResult_ShouldCallInvocationProceed()
        {
            // Arrange
            var mockedCachingProvider = new Mock<ICachingProvider>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var interceptor = new CachingInterceptor(mockedCachingProvider.Object, mockedDateTimeProvider.Object);

            var mockedMethodInfo = new Mock<MethodInfo>();

            var mockedRequest = new Mock<IProxyRequest>();
            mockedRequest.Setup(r => r.Method).Returns(mockedMethodInfo.Object);

            var mockedInvocation = new Mock<IInvocation>();
            mockedInvocation.Setup(i => i.Request).Returns(mockedRequest.Object);

            // Act
            interceptor.Intercept(mockedInvocation.Object);

            // Assert
            mockedInvocation.Verify(i => i.Proceed(), Times.Once);
        }

        [Test]
        public void TestIntercept_CachingProviderDoesNotReturnResult_ShouldCallInvocationReturnValue()
        {
            // Arrange
            var mockedCachingProvider = new Mock<ICachingProvider>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var interceptor = new CachingInterceptor(mockedCachingProvider.Object, mockedDateTimeProvider.Object);

            var mockedMethodInfo = new Mock<MethodInfo>();

            var mockedRequest = new Mock<IProxyRequest>();
            mockedRequest.Setup(r => r.Method).Returns(mockedMethodInfo.Object);

            var mockedInvocation = new Mock<IInvocation>();
            mockedInvocation.Setup(i => i.Request).Returns(mockedRequest.Object);

            // Act
            interceptor.Intercept(mockedInvocation.Object);

            // Assert
            mockedInvocation.Verify(i => i.ReturnValue, Times.Once);
        }

        [Test]
        public void TestIntercept_CachingProviderDoesNotReturnResult_ShouldCallDateTimeProviderGetTimeFromCurrentTime()
        {
            // Arrange
            var mockedCachingProvider = new Mock<ICachingProvider>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            var interceptor = new CachingInterceptor(mockedCachingProvider.Object, mockedDateTimeProvider.Object);

            var mockedMethodInfo = new Mock<MethodInfo>();

            var mockedRequest = new Mock<IProxyRequest>();
            mockedRequest.Setup(r => r.Method).Returns(mockedMethodInfo.Object);

            var mockedInvocation = new Mock<IInvocation>();
            mockedInvocation.Setup(i => i.Request).Returns(mockedRequest.Object);

            // Act
            interceptor.Intercept(mockedInvocation.Object);

            // Assert
            mockedDateTimeProvider.Verify(p => p.GetTimeFromCurrentTime(Constants.HoursCaching,
                    Constants.MinutesCaching,
                    Constants.SecondsCaching),
                Times.Once);
        }

        [TestCase("MyAwesomeMethod")]
        [TestCase("DoSomething")]
        public void TestIntercept_CachingProviderDoesNotReturnResult_ShouldCallCachingProviderAddItem(string methodName)
        {
            // Arrange
            var mockedCachingProvider = new Mock<ICachingProvider>();

            var date = new DateTime();

            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            mockedDateTimeProvider.Setup(
                    p => p.GetTimeFromCurrentTime(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(date);

            var interceptor = new CachingInterceptor(mockedCachingProvider.Object, mockedDateTimeProvider.Object);

            var mockedMethodInfo = new Mock<MethodInfo>();
            mockedMethodInfo.Setup(m => m.Name).Returns(methodName);

            var mockedRequest = new Mock<IProxyRequest>();
            mockedRequest.Setup(r => r.Method).Returns(mockedMethodInfo.Object);

            var returnValue = new object();

            var mockedInvocation = new Mock<IInvocation>();
            mockedInvocation.Setup(i => i.Request).Returns(mockedRequest.Object);
            mockedInvocation.Setup(i => i.ReturnValue).Returns(returnValue);

            // Act
            interceptor.Intercept(mockedInvocation.Object);

            // Assert
            mockedCachingProvider.Verify(p => p.AddItem(methodName, returnValue, date), Times.Once);
        }
    }
}
