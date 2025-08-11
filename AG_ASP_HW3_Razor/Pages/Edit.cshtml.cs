using AP_Films.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace AP_Films.Pages
{
    public class EditModel : PageModel
    {
        private readonly MovieContext context;
        private readonly IWebHostEnvironment env;
        [BindProperty] public Movie Movie { get; set; }
        [BindProperty] public IFormFile UploadedPoster { get; set; }
        public EditModel(MovieContext c, IWebHostEnvironment e) { context = c; env = e; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Movie = await context.Movies.FindAsync(id);
            if (Movie == null) return NotFound();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Movie.Poster");
            if (!ModelState.IsValid) return Page();
            var existing = await context.Movies.FindAsync(Movie.Id);
            if (existing == null) return NotFound();
            if (UploadedPoster != null)
            {
                if (!string.IsNullOrEmpty(existing.Poster))
                {
                    string old = Path.Combine(env.WebRootPath, existing.Poster.TrimStart('/'));
                    if (System.IO.File.Exists(old)) System.IO.File.Delete(old);
                }
                string fileName = Path.GetFileName(UploadedPoster.FileName);
                string rel = "/images/" + fileName;
                string full = Path.Combine(env.WebRootPath, "images", fileName);
                using var s = new FileStream(full, FileMode.Create);
                await UploadedPoster.CopyToAsync(s);
                existing.Poster = rel;
            }
            existing.Title = Movie.Title;
            existing.Director = Movie.Director;
            existing.Genre = Movie.Genre;
            existing.Year = Movie.Year;
            existing.Description = Movie.Description;
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}