using Ganss.Xss;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using RecipeCatalog.Data;
using RecipeCatalog.Model;
using RecipeCatalog.Model.Recipes;

namespace RecipeCatalog.Controllers;

public class RecipesController : Controller
{
    private readonly ApplicationDbContext _context;

    public RecipesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var model = new RecipesViewModel
        {
            Recipes = _context.Recipes.Include(r => r.Category).Include(r => r.RecipeIngredients).ToList()
        };
        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int id = 0)
    {
        Recipe? recipe;
        if (id == 0)
        {
            recipe = new Recipe { Name = "", Description = "", Category = new Category { Name = "" } };
        }
        else
        {
            recipe = _context.Recipes
                .Include(r => r.Category)
                .FirstOrDefault(r => r.Id == id);
            if (recipe == null) return NotFound();
        }

        var model = new RecipeEditViewModel
        {
            Recipe = recipe,
            Categories = _context.Categories.ToList()
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(RecipeEditViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Categories = _context.Categories.ToList();
            if (ModelState.TryGetValue("Recipe.CategoryId", out var entry)
                && entry.ValidationState == ModelValidationState.Invalid)
            {
                ModelState.Remove("Recipe.CategoryId");
                ModelState.AddModelError("Recipe.CategoryId", "Необходимо указать категорию.");
            }

            return View(model);
        }

        var sanitizer = new HtmlSanitizer();
        model.Recipe.Description = sanitizer.Sanitize(model.Recipe.Description);

        if (model.Recipe.Id == 0)
            _context.Recipes.Add(model.Recipe);
        else
            _context.Recipes.Update(model.Recipe);

        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id = 0)
    {
        if (id == 0) return NotFound();

        var recipe = _context.Recipes.FirstOrDefault(r => r.Id == id);
        if (recipe == null) return NotFound();

        _context.Recipes.Remove(recipe);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}