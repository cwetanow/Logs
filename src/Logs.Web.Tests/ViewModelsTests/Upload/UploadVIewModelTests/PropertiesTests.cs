using CloudinaryDotNet;
using Logs.Web.Models.Upload;
using NUnit.Framework;

namespace Logs.Web.Tests.ViewModelsTests.Upload.UploadVIewModelTests
{
    [TestFixture]
    public class PropertiesTests
    {
        [TestCase("cloud", "apiKey", "apiSecret")]
        public void TestCloudinary_ShouldSetCorrectly(string cloud, string apiKey, string apiSecret)
        {
            // Arrange
            var account = new CloudinaryDotNet.Account(cloud, apiKey, apiSecret);
            var cloudinary = new Cloudinary(account);

            var model = new UploadViewModel();

            // Act
            model.Cloudinary = cloudinary;

            // Assert
            Assert.AreSame(cloudinary, model.Cloudinary);
        }
    }
}
