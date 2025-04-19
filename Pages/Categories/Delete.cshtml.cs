using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeCatalog.Data;
using RecipeCatalog.Model;

namespace RecipeCatalog.Pages.Categories;

public class CategoryDeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CategoryDeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet(int id)
    {
        Category? category = _context.Categories.FirstOrDefault(b => b.Id == id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        return RedirectToPage("Index");
    }
}