using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.Domain
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "Heading cannot be longer than 150 characters.")]
        public string Heading { get; set; }

        [Required]
        //[StringLength(150)]
        public string PageTitle { get; set; }

        [Url]
        //[Display(Name = "Featured Image URL")]
        public string FeaturedImageUrl { get; set; }

        [Required]
        //[DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        [StringLength(300, ErrorMessage = "Short description cannot exceed 300 characters.")]
        public string ShortDescription { get; set; }

        [Required]
        //[StringLength(100)]
        public string Author { get; set; }

        [Required]
        [RegularExpression(@"^[a-z0-9\-]+$", ErrorMessage = "UrlHandle must be lowercase letters, numbers, or hyphens.")]
        public string UrlHandle { get; set; }

        [Required]
        public bool Visible { get; set; }

        public ICollection<Tags> Tags { get; set; }




    }
}
