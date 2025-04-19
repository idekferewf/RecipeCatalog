using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeCatalog.Data;
using RecipeCatalog.Model;

namespace RecipeCatalog.Pages.Categories;

public class CategoryModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CategoryModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public Category? Category { get; set; }

    public IActionResult OnGet(int id)
    {
        if (id > 0)
        {
            Category? category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            Category = category;
        }
        else
        {
            Category = new Category { Name = "", Recipes = new List<Recipe>() };
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        if (Category != null)
        {
            if (Category.Id == 0)
                _context.Categories.Add(Category);
            else
                _context.Categories.Update(Category);
            _context.SaveChanges();
        }

        return RedirectToPage("Index");
    }
}