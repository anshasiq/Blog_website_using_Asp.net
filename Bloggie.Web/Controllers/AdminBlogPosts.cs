using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bloggie.Web.Controllers
{
    public class AdminBlogPosts : Controller
    {
        private readonly ITagRepo tagRepository;
        private readonly IBlogPostRepo blogPostRepo;

        public AdminBlogPosts(ITagRepo tagRepository, IBlogPostRepo blogPostRepo)
        {
            this.tagRepository = tagRepository;
            this.blogPostRepo = blogPostRepo;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View("Index");
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var tags = await tagRepository.GetAllTagsAsync();
            //string json = JsonSerializer.Serialize(tags, new JsonSerializerOptions
            //{
            //    WriteIndented = true // makes it pretty-printed
            //});

            //Console.WriteLine(json);
            var model = new AddBlogPostReq
            {
                Tags = tags.Select(t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.DisplayName
                })
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddBlogPostReq addBlogPostReq)
        {
            var BlogPost = new BlogPost
            {
                Heading = addBlogPostReq.Heading,
                PageTitle = addBlogPostReq.PageTitle,
                Content = addBlogPostReq.Content,
                ShortDescription = addBlogPostReq.ShortDescription,
                FeaturedImageUrl = addBlogPostReq.FeaturedImageUrl,
                UrlHandle = addBlogPostReq.UrlHandle,
                Author = addBlogPostReq.Author,
                Created = addBlogPostReq.Created,
                Visible = addBlogPostReq.Visible,
                //SelectedTagId = addBlogPostReq.SelectedTagId

            };

            foreach (var tagId in addBlogPostReq.SelectedTagId)
            {
                var tag = await tagRepository.GetTagByIdAsync(Guid.Parse(tagId));
                if (tag != null)
                {
                    BlogPost.Tags ??= new List<Tags>();
                    BlogPost.Tags.Add(tag);
                }
            }
            await blogPostRepo.AddBlogAsync(BlogPost);

            string json = JsonSerializer.Serialize(addBlogPostReq, new JsonSerializerOptions
            {
                WriteIndented = true // makes it pretty-printed
            });

            Console.WriteLine(json);
            return RedirectToAction("Add");

        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ListOfBlog()
        {
            //GetAllBlogsAsync();
            var blogPosts = await blogPostRepo.GetAllBlogsAsync();
            return View(blogPosts);
        }
        //[HttpDelete]
        //public Task<IActionResult> Delete(Guid id)
        //{
        //     blogPostRepo.DeleteBlogAsync(id);
        //    return RedirectToAction(nameof(ListOfBlog));
        //}
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            await blogPostRepo.DeleteBlogAsync(id);
            return RedirectToAction(nameof(ListOfBlog));
        }

    }
}
