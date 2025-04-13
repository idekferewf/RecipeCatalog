using Microsoft.AspNetCore.Mvc;
using RecipeCatalog.Data;

namespace RecipeCatalog.Controllers;

public class RecipesController : Controller
{
    private readonly ApplicationDbContext _context;

    public RecipesController(ApplicationDbContext context)
    {
        _context = context;
    }
}