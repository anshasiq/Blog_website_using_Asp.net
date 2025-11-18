using Bloggie.Web.Models;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repo;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace Bloggie.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogPostRepo blogPostRepo;

        public HomeController(ILogger<HomeController> logger, IBlogPostRepo blogPostRepo)
        {
            this.blogPostRepo = blogPostRepo;
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var blogPosts = await blogPostRepo.GetAllBlogsAsync();
            //string json = JsonSerializer.Serialize(blogPosts, new JsonSerializerOptions
            //{
            //    WriteIndented = true,
            //    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
            //});

            //Console.WriteLine(json);
            return View(blogPosts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
