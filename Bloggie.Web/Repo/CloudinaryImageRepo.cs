using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Bloggie.Web.Repo
{
    public class CloudinaryImageRepo
    {
        private readonly IConfiguration configuration;
        private readonly Account account;

        public CloudinaryImageRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
            account = new Account(
                configuration.GetSection("Cloudinary")["CloudName"],
                configuration.GetSection("Cloudinary")["ApiKey"],
                configuration.GetSection("Cloudinary")["ApiSecret"]);
        }

        
        public async Task<string> UploadImageAsync(IFormFile file)
        { 
            var cloudinary = new Cloudinary(account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                DisplayName = file.FileName
            };
            var uploadResult = await cloudinary.UploadAsync(uploadParams);
            //return uploadResult.SecureUrl.ToString();
            if (uploadResult != null && uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadResult.SecureUrl.ToString();
            }

            return null;

        }

    }
}
