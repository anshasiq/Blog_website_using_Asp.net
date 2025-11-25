using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.ViewModels
{
    public class RegisterViewModel
    {
        
        public required string Username { get; set; }
        public required string EmailAddress { get; set; }
        public required string Password { get; set; }
       
    }
}
