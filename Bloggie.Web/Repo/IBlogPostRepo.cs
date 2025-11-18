using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repo
{
    public interface IBlogPostRepo
    {
        Task<IEnumerable<BlogPost>> GetAllBlogsAsync();

        Task<BlogPost?> GetBlogByIdAsync(Guid id);
        Task<BlogPost> AddBlogAsync(BlogPost blogPost);
        //Task<BlogPost?> UpdateTagAsync(Guid id, string displayName);
        //Task<Tags?> DeleteTagAsync(Guid id);
        Task<BlogPost?> GetByUrlHandleAsync(string urlHandle);
        Task DeleteBlogAsync(Guid id);
    }
}
