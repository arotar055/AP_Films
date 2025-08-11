using Microsoft.AspNetCore.Mvc.RazorPages;
using AP_Films.Models;
using System.Collections.Generic;
using System.Linq;

namespace AP_Films.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MovieContext context;
        public List<Movie> Movies { get; set; }
        public IndexModel(MovieContext c) { context = c; }
        public void OnGet() { Movies = context.Movies.ToList(); }
    }
}