using AP_Films.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Threading.Tasks;

namespace AP_Films.Pages
{
    public class CreateModel : PageModel
    {
        private readonly MovieContext context;
        private readonly IWebHostEnvironment env;
        [BindProperty] public Movie Movie { get; set; }
        [BindProperty] public IFormFile UploadedPoster { get; set; }
        public CreateModel(MovieContext c, IWebHostEnvironment e) { context = c; env = e; }
        public void OnGet() { }
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Movie.Poster");
            if (!ModelState.IsValid) return Page();
            if (UploadedPoster != null)
            {
                string fileName = Path.GetFileName(UploadedPoster.FileName);
                string rel = "/images/" + fileName;
                string full = Path.Combine(env.WebRootPath, "images", fileName);
                using var s = new FileStream(full, FileMode.Create);
                await UploadedPoster.CopyToAsync(s);
                Movie.Poster = rel;
            }
            context.Movies.Add(Movie);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}