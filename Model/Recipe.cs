using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeCatalog.Model
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимо указать название рецепта.")]
        [StringLength(255, ErrorMessage = "Максимальная длина названия рецепта - 255 символов.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Необходимо указать категорию рецепта.")]
        public required int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public required Category Category { get; set; }

        [Required]
        public required List<RecipeIngredient> RecipeIngredients { get; set; } = [];

        [Required]
        public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
