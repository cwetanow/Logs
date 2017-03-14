using CloudinaryDotNet;

namespace Logs.Web.Models.Upload
{
    public class UploadViewModel
    {
        public UploadViewModel(Cloudinary cloudinary, string imageUrl)
        {
            this.Cloudinary = cloudinary;
            this.ImageUrl = imageUrl;
        }

        public UploadViewModel()
        {
            
        }

        public Cloudinary Cloudinary { get; set; }

        public string ImageUrl { get; set; }
    }
}