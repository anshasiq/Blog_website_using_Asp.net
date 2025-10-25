using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.Domain
{
    public class Tags
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Display Name is required")]
        public string DisplayName { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<BlogPost> BlogPosts { get; set; }

    }
}
