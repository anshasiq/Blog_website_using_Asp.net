using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bloggie.Web.Models.ViewModels
{
    public class AddBlogPostReq
    {
        public string Heading { get; set; }
        public string PageTitle { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime Created { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }
        public IEnumerable<SelectListItem> Tags { get; set; }
        public string [] SelectedTagId { get; set; } = Array.Empty<string>();
    }
}
