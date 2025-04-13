using Microsoft.AspNetCore.Mvc;
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
}