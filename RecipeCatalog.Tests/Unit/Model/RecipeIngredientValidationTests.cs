using System.ComponentModel.DataAnnotations;
using RecipeCatalog.Model;

namespace RecipeCatalog.Tests.Unit.Model;

public class RecipeIngredientValidationTests
{
    [Fact]
    public void RecipeIngredient_WithValidData_ShouldBeValid()
    {
        // создание объекта рецепта
        var recipe = new Recipe
        {
            Id = 1,
            Name = "Шоколадный мусс",
            Description = "Легкий воздушный десерт из темного шоколада и взбитых сливок.",
            CategoryId = 2,
            Category = new Category { Id = 2, Name = "Десерты" },
            CreatedAt = DateTime.UtcNow.AddDays(-2)
        };

        // создание объекта ингредиента
        var ingredient = new Ingredient
        {
            Id = 1,
            Name = "Темный шоколад",
            Unit = "г"
        };

        // создание объекта с валидными данными
        var recipeIngredient = new RecipeIngredient
        {
            RecipeId = recipe.Id,
            Recipe = recipe,
            IngredientId = ingredient.Id,
            Ingredient = ingredient,
            Quantity = 150
        };

        // создание контекста валидации на основе объекта
        var context = new ValidationContext(recipeIngredient);

        // ошибки валидации, если они есть
        var result = new List<ValidationResult>();

        // валидация объекта с учетом всех атрибутов ([Required], [Range] и т.п.)
        var isValid = Validator.TryValidateObject(recipeIngredient, context, result, true);

        Assert.True(isValid);
        Assert.Empty(result);
    }
}