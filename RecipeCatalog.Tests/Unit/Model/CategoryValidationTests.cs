using System.ComponentModel.DataAnnotations;
using RecipeCatalog.Model;

namespace RecipeCatalog.Tests.Unit.Model;

public class CategoryValidationTests
{
    [Fact]
    public void Category_WithValidData_ShouldBeValid()
    {
        // создание объекта категории с валидными данными
        var category = new Category
        {
            Name = "Салаты",
        };

        // создание контекста валидации на основе объекта
        var context = new ValidationContext(category);

        // ошибки валидации, если они есть
        var result = new List<ValidationResult>();

        // валидация объекта с учетом всех атрибутов ([Required], [Range] и т.п.)
        var isValid = Validator.TryValidateObject(category, context, result, true);

        Assert.True(isValid);
        Assert.Empty(result);
    }

    [Fact]
    public void Category_WithEmptyName_ShouldBeInvalid()
    {
        // создание объекта категории с пустым названием
        var category = new Category
        {
            Name = "",
        };

        // валидация объекта
        var context = new ValidationContext(category);
        var result = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(category, context, result, true);

        Assert.False(isValid);

        // проверка, что ошибка касается конкретно названия
        Assert.Contains(result, r => r.ErrorMessage == "Необходимо указать название категории.");
    }
}