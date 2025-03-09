using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeCatalog.Model
{
    public class RecipeIngredient
    {
        public int Id { get; set; }

        [Required]
        public required int RecipeId { get; set; }

        [Required]
        [ForeignKey("RecipeId")]
        public required Recipe Recipe { get; set; }

        [Required]
        public required int IngredientId { get; set; }

        [Required]
        [ForeignKey("IngredientId")]
        public required Ingredient Ingredient { get; set; }

        [Required]
        [Column(TypeName = "decimal(6, 3)")]
        public required decimal Quantity { get; set; }
    }
}
