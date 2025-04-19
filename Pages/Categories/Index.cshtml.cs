using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeCatalog.Data;
using RecipeCatalog.Model;

namespace RecipeCatalog.Pages.Categories;

public class CategoriesModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CategoriesModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public required List<Category> Categories { get; set; }

    public void OnGet()
    {
        Categories = _context.Categories.Include(c => c.Recipes).ToList();
    }
}