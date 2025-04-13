using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeCatalog.Model;
using RecipeCatalog.Data;

namespace RecipeCatalog.Controllers;

public class RecipesController : Controller
{
    private readonly ApplicationDbContext _context;

    public RecipesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public class RecipeEditViewModel
    {
        public required Recipe Recipe { get; set; }
        public List<Category> Categories { get; set; } = [];
    }

    [HttpGet]
    public IActionResult Edit(int id = 0)
    {
        Recipe? recipe;
        if (id == 0)
        {
            recipe = new Recipe();
        }
        else
        {
            recipe = _context.Recipes
                .Include(r => r.Category)
                .FirstOrDefault(r => r.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
        }

        RecipeEditViewModel model = new RecipeEditViewModel
        {
            Recipe = recipe,
            Categories = _context.Categories.ToList()
        };
        return View(model);
    }
}