using Bloggie.Web.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Image : ControllerBase
    {
        private readonly CloudinaryImageRepo cloudinaryImageRepo;
        public Image (CloudinaryImageRepo cloudinaryImageRepo)
        {
            this.cloudinaryImageRepo = cloudinaryImageRepo;
        }

        //[HttpGet]
        //public IActionResult index()
        //{
        //    return Ok("asdasdasd");
        //}
        [HttpPost("upload")]

        public async Task<IActionResult> UploadImageAsync(IFormFile file)
        {
            
            var image = await cloudinaryImageRepo.UploadImageAsync(file);

            if (image == null || file.Length == 0)
                return BadRequest("No file uploaded.");
            // Here you would typically save the file to a storage location
            // For demonstration, we'll just return the file name and size
            var fileInfo = new
            {
                FileName = file.FileName,
                Size = file.Length
            };
            return Ok(new { ImageUrl = image });
            //return Ok(fileInfo);

        }
    }
}
