using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repo
{
    public class TagRepo : ITagRepo
    {
        private readonly BloggieDbContext bloggieDbContext;

        public TagRepo(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }
        public async Task<Tags> AddTagAsync(Tags tag)
        {  
            await bloggieDbContext.Tags.AddAsync(tag);
            await bloggieDbContext.SaveChangesAsync();
            return tag;
            //throw new NotImplementedException();
        }

        public async Task DeleteTagAsync(Guid id)
        {
            var tag = await bloggieDbContext.Tags.FindAsync(id);
            bloggieDbContext.Remove(tag);
            await bloggieDbContext.SaveChangesAsync();
           
        }

        public async Task<IEnumerable<Tags>> GetAllTagsAsync()
        {
          return await bloggieDbContext.Tags.ToListAsync();
           
        }

        public Task<Tags> GetTagByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Tags?> UpdateTagAsync(Guid id, string displayName)
        {
            var tag =  await bloggieDbContext.Tags.FindAsync(id);
            if (tag == null)
            {
                return null;
            }
            tag.DisplayName = displayName;
            await bloggieDbContext.SaveChangesAsync();
            return tag;
            
            //throw new NotImplementedException();
        }
    }
}
