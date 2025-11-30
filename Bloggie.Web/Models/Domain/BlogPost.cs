using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.Domain
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        [Required]
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


        
        public string ShortDescription { get; set; }

     
        //[StringLength(100)]
        public string Author { get; set; }

      
        public string UrlHandle { get; set; }

       
        public bool Visible { get; set; }

        public ICollection<Tags> Tags { get; set; }

        public ICollection<BlogPostLike> Likes { get; set; }


    }
}
