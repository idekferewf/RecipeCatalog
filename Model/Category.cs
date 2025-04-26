using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RecipeCatalog.Model;

public class Category
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Необходимо указать название категории.")]
    [StringLength(255, ErrorMessage = "Максимальная длина названия категории - 255 символов.")]
    public required string Name { get; set; }

    [ValidateNever] public List<Recipe> Recipes { get; set; } = [];
}