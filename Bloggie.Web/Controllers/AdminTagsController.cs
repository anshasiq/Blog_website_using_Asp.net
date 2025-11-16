using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;



namespace Bloggie.Web.Controllers
{
    
    

    public class AdminTagsController : Controller
    {
        private readonly ITagRepo tagRepo;
        public AdminTagsController(ITagRepo tagRepo)
        {
            this.tagRepo = tagRepo;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Tags model)
        {
            var name = model.Name;
            var displayName = model.DisplayName;

            var tag = new Tags
            {
                Name = name,
                DisplayName = displayName,
                CreatedAt = DateTime.Now, // ensure timestamp
            };
            try
            {
                await tagRepo.AddTagAsync(tag); 
                TempData["SuccessMessage"] = "Saved successfully!";
            }
            catch
            {
                TempData["SuccessMessage"] = "Saved Unsuccessfully!";
                return View("Add");
            }
            Console.WriteLine($"Name: {name}, Display Name: {displayName}");

            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            var tags = await tagRepo.GetAllTagsAsync();
            Console.WriteLine(tags);
            string json = JsonSerializer.Serialize(tags, new JsonSerializerOptions
            {
                WriteIndented = true // makes it pretty-printed
            });

            Console.WriteLine(json);
            return View(tags);

        }
        [HttpGet]
        public async Task<IActionResult> GetTagById(Guid id)
        {   var tag = await tagRepo.GetTagByIdAsync(id);
            Console.WriteLine("here ");
            if (tag == null)
            {
                Console.WriteLine("Not found ");
                return NotFound();
            }
            string json = JsonSerializer.Serialize(tag, new JsonSerializerOptions
            {
                WriteIndented = true // makes it pretty-printed
            });
            Console.WriteLine("From hhere" + json );
            return Ok(tag);
            //return View("List", tag);
        }

        [HttpPost]
        public async Task<IActionResult> EditInline(Guid id, string displayName)
        {
            await tagRepo.UpdateTagAsync(id,displayName);
            TempData["SuccessMessage"] = "Tag updated successfully!";
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public async Task<IActionResult> Delet(Guid id)
        {
           await tagRepo.DeleteTagAsync(id);
            return RedirectToAction(nameof(List));
        }

    }
}
