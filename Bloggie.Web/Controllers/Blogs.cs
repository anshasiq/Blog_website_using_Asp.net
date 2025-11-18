using Bloggie.Web.Repo;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    public class Blogs : Controller

    {
        private readonly IBlogPostRepo blogPostRepo;
        public Blogs(IBlogPostRepo blogPostRepo) 
        {
        this.blogPostRepo = blogPostRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)
        {
           var blogPost = await blogPostRepo.GetByUrlHandleAsync(urlHandle);
            //var json = System.Text.Json.JsonSerializer.Serialize(blogPost, new System.Text.Json.JsonSerializerOptions
            //{
            //    WriteIndented = true,
            //    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
            //});
            return View(blogPost);
        }
    }
}
