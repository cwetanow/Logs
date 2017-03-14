using CloudinaryDotNet;

namespace Logs.Web.Infrastructure.Factories
{
    public interface ICloudinaryFactory
    {
        Cloudinary GetCloudinary();
    }
}
