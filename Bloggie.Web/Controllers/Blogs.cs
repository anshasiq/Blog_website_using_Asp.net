using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repo;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    public class Blogs : Controller

    {
        private readonly IBlogPostRepo blogPostRepo;
        private readonly BlogPostLikeRepo blogPostLikeRepo;
        public Blogs(IBlogPostRepo blogPostRepo,BlogPostLikeRepo blogPostLikeRepo) 
        {
        this.blogPostRepo = blogPostRepo;
        this.blogPostLikeRepo = blogPostLikeRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)
        {
           var blogPost = await blogPostRepo.GetByUrlHandleAsync(urlHandle);
           var blogDetailsViewModel = new BlogDetailsViewModel();
            var TotalLike = await blogPostLikeRepo.GetTotalLikes(blogPost.Id);
            if (blogPost != null)
            {
                blogDetailsViewModel = new BlogDetailsViewModel
                {
                    Id = blogPost.Id,
                    Heading = blogPost.Heading,
                    PageTitle = blogPost.PageTitle,
                    Content = blogPost.Content,
                    ShortDescription = blogPost.ShortDescription,
                    FeaturedImageUrl = blogPost.FeaturedImageUrl,
                    UrlHandle = blogPost.UrlHandle,
                    PublishedDate = blogPost.Created,
                    Author = blogPost.Author,
                    Visible = blogPost.Visible,
                    Tags = blogPost.Tags,
                    TotalLikes = TotalLike,
                    Liked = false
                };

            }
            //var json = System.Text.Json.JsonSerializer.Serialize(blogPost, new System.Text.Json.JsonSerializerOptions
            //{
            //    WriteIndented = true,
            //    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
            //});
            return View(blogDetailsViewModel);
        }
    }
}
