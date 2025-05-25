using System.ComponentModel.DataAnnotations;
using RecipeCatalog.Model;

namespace RecipeCatalog.Tests.Unit.Model;

public class RecipeValidationTests
{
    [Fact]
    public void Recipe_WithValidData_ShouldBeValid()
    {
        // создание объекта рецепта с валидными данными
        var recipe = new Recipe
        {
            Name = "Паста Карбонара",
            Description =
                "Классический итальянский рецепт пасты с соусом из яиц, сыра пармезан, гуанчиале и черного перца.",
            CategoryId = 1,
            Category = new Category { Id = 1, Name = "Основные блюда" },
            CreatedAt = DateTime.UtcNow.AddDays(-5)
        };

        // создание контекста валидации на основе объекта
        var context = new ValidationContext(recipe);

        // ошибки валидации, если они есть
        var result = new List<ValidationResult>();

        // валидация объекта с учетом всех атрибутов ([Required], [Range] и т.п.)
        var isValid = Validator.TryValidateObject(recipe, context, result, true);

        Assert.True(isValid);
        Assert.Empty(result);
    }

    [Fact]
    public void Recipe_WithEmptyName_ShouldBeInvalid()
    {
        // создание объекта рецепта с пустым названием
        var recipe = new Recipe
        {
            Name = "",
            Description = "Легкий воздушный десерт из темного шоколада и взбитых сливок.",
            CategoryId = 2,
            Category = new Category { Id = 2, Name = "Десерты" },
            CreatedAt = DateTime.UtcNow.AddDays(-2)
        };

        // валидация объекта
        var context = new ValidationContext(recipe);
        var result = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(recipe, context, result, true);

        Assert.False(isValid);

        // проверка, что ошибка касается конкретно названия
        Assert.Contains(result, r => r.ErrorMessage == "Необходимо указать название рецепта.");
    }
}