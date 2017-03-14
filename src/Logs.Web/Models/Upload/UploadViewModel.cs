using CloudinaryDotNet;

namespace Logs.Web.Models.Upload
{
    public class UploadViewModel
    {
        public UploadViewModel()
        {
            var account = new CloudinaryDotNet.Account(
  "cwetanow",
  "742665798753294",
  "7dLDYfT_LfNCGI9FPtyEG7G8dm0");

            this.Cloudinary = new Cloudinary(account);
        }

        public Cloudinary Cloudinary { get; set; }

        public string ImageUrl { get; set; }
    }
}