using Microsoft.AspNetCore.Mvc;
using RecipeCatalog.Data;
using RecipeCatalog.Model;

namespace RecipeCatalog.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : Controller
{
    private readonly ApplicationDbContext _context;

    public CategoriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
        var categories = _context.Categories.ToList();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public IActionResult GetCategory(int id)
    {
        var category = _context.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost]
    public IActionResult CreateCategory([FromBody] Category category)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Categories.Add(category);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory(int id, [FromBody] Category category)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingCategory = _context.Categories.Find(id);
        if (existingCategory == null)
        {
            return NotFound();
        }

        existingCategory.Name = category.Name;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var category = _context.Categories.Find(id);
        if (category == null)
        {
            return NotFound();
        }

        _context.Categories.Remove(category);
        _context.SaveChanges();

        return NoContent();
    }
}