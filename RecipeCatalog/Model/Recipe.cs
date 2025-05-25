using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RecipeCatalog.Model;

public class Recipe
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Необходимо указать название рецепта.")]
    [StringLength(255, ErrorMessage = "Максимальная длина названия рецепта - 255 символов.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Необходимо указать описание рецепта.")]
    public required string Description { get; set; }

    [Required(ErrorMessage = "Необходимо указать категорию рецепта.")]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [ValidateNever]
    public required Category Category { get; set; }

    [ValidateNever] public List<RecipeIngredient> RecipeIngredients { get; set; } = [];

    [ValidateNever] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}