using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeCatalog.Model
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public required string Name { get; set; }

        [Required]
        public required int CategoryId { get; set; }

        [Required]
        [ForeignKey("CategoryId")]
        public required Category Category { get; set; }

        [Required]
        public required List<RecipeIngredient> RecipeIngredients { get; set; } =
            new List<RecipeIngredient>();

        [Required]
        public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
