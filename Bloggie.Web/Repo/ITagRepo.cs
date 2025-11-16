using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repo
{
    public interface ITagRepo
    {
        Task <IEnumerable <Tags>> GetAllTagsAsync();

        Task<Tags?> GetTagByIdAsync(Guid id);
        Task<Tags> AddTagAsync(Tags tag);
        Task<Tags?> UpdateTagAsync(Guid id, string displayName);
        //Task<Tags?> DeleteTagAsync(Guid id);

        Task DeleteTagAsync(Guid id);


    }
}
