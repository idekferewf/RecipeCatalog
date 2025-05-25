using System.ComponentModel.DataAnnotations;
using RecipeCatalog.Model;

namespace RecipeCatalog.Tests.Unit.Model;

public class IngredientValidationTests
{
    [Fact]
    public void Ingredient_WithValidData_ShouldBeValid()
    {
        // создание объекта ингредиента с валидными данными
        var ingredient = new Ingredient
        {
            Name = "Темный шоколад",
            Unit = "г",
        };

        // создание контекста валидации на основе объекта
        var context = new ValidationContext(ingredient);

        // ошибки валидации, если они есть
        var result = new List<ValidationResult>();

        // валидация объекта с учетом всех атрибутов ([Required], [Range] и т.п.)
        var isValid = Validator.TryValidateObject(ingredient, context, result, true);

        Assert.True(isValid);
        Assert.Empty(result);
    }

    [Fact]
    public void Ingredient_WithEmptyName_ShouldBeInvalid()
    {
        // создание объекта ингредиента с пустым названием
        var ingredient = new Ingredient
        {
            Name = "",
            Unit = "мл",
        };

        // валидация объекта
        var context = new ValidationContext(ingredient);
        var result = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(ingredient, context, result, true);

        Assert.False(isValid);

        // проверка, что ошибка касается конкретно названия
        Assert.Contains(result, r => r.ErrorMessage == "Необходимо указать название ингредиента.");
    }
}