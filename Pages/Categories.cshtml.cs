using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeCatalog.Data;
using RecipeCatalog.Model;

namespace RecipeCatalog.Pages
{
    public class CategoriesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public List<Category>? Categories { get; set; }

        public CategoriesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Categories = _context.Categories.Include(c => c.Recipes).ToList();
        }
    }
}
