using Azure;
using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repo
{
    public class BlogPostRepo : IBlogPostRepo
    {
        private readonly BloggieDbContext bloggieDbContext;


        public BlogPostRepo(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }
        public async Task<BlogPost> AddBlogAsync(BlogPost blogPost)
        {
           await bloggieDbContext.BlogPosts.AddAsync(blogPost);
            await bloggieDbContext.SaveChangesAsync();
            return blogPost;

            //throw new NotImplementedException();
        }

        public async Task DeleteBlogAsync(Guid id)
        {
            var blogPost = await bloggieDbContext.BlogPosts.FindAsync(id);
             bloggieDbContext.Remove(blogPost);
            await bloggieDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogPost>> GetAllBlogsAsync()
        {
            return await bloggieDbContext.BlogPosts.Include(x=>x.Tags).ToListAsync();
        }

        public Task<BlogPost?> GetBlogByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
            return await bloggieDbContext.BlogPosts.Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }
    }
    
}
