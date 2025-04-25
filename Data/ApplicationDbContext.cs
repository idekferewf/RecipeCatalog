using Microsoft.EntityFrameworkCore;
using RecipeCatalog.Model;
using RecipeCatalog.Model.Auth;

namespace RecipeCatalog.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.Migrate();
    }

    public DbSet<Recipe> Recipes { get; set; } // таблица Recipe, содержащая данные о рецептах.
    public DbSet<Ingredient> Ingredients { get; set; } // таблица Ingredient, содержащая данные об ингредиентах.
    public DbSet<Category> Categories { get; set; } // таблица Category, содержащая данные о категориях рецептов.

    public DbSet<RecipeIngredient>
        RecipeIngredients { get; set; } // таблица RecipeIngredient, связующая таблицы Recipe и Ingredient.
    public DbSet<User> Users { get; set; }
}