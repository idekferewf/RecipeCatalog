using System.ComponentModel.DataAnnotations;

namespace RecipeCatalog.Model
{
    public class Ingredient
    {
        [Required]
        public required int Id { get; set; }

        [Required]
        [StringLength(255)]
        public required string Name { get; set; }

        [Required]
        [StringLength(30)]
        public required string Unit { get; set; }

        [Required]
        public required List<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
