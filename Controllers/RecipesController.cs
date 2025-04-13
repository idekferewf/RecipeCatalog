using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        if (model.Recipe.Id == 0)
        {
            _context.Recipes.Add(model.Recipe);
        }
        else
        {
            _context.Recipes.Update(model.Recipe);
        }

        _context.SaveChanges();

        return RedirectToAction("Edit", new { id = model.Recipe.Id });
    }

    [HttpPost]
    public IActionResult Delete(RecipeEditViewModel model)
    {
        if (model.Recipe.Id == 0)
        {
            return NotFound();
        }

        _context.Recipes.Remove(model.Recipe);
        _context.SaveChanges();

        return RedirectToAction("Edit");
    }
}