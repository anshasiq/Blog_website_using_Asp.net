using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostLikeController : ControllerBase
    {
        private readonly BlogPostLikeRepo blogPostLikeRepo;
        public BlogPostLikeController(BlogPostLikeRepo blogPostLikeRepo)
        {
            this.blogPostLikeRepo = blogPostLikeRepo;
        }
            [Authorize]
            [HttpPost]
            [Route("Add")]
            public async Task<IActionResult> AddLike([FromBody] AddLikeRequest addLikeRequest)
            {
                var model = new BlogPostLike
                {
                    BlogPostId = addLikeRequest.BlogPostId,
                    UserId = addLikeRequest.UserId
                };

                await blogPostLikeRepo.AddLikeForBlog(model);

                return Ok();
            }

           
            [HttpGet]
            [Route("{blogPostId:Guid}/totalLikes")]
            public async Task<IActionResult> GetTotalLikesForBlog([FromRoute] Guid blogPostId)
            {
                var totalLikes = await blogPostLikeRepo.GetTotalLikes(blogPostId);

                return Ok(totalLikes);
            }
        }
}
