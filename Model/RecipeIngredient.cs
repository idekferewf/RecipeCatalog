using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeCatalog.Model
{
    public class RecipeIngredient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимо указать рецепт.")]
        public required int RecipeId { get; set; }

        [ForeignKey("RecipeId")]
        public required Recipe Recipe { get; set; }

        [Required(ErrorMessage = "Необходимо указать ингредиент.")]
        public required int IngredientId { get; set; }

        [ForeignKey("IngredientId")]
        public required Ingredient Ingredient { get; set; }

        [Required(ErrorMessage = "Необходимо указать количество ингредиента.")]
        [Column(TypeName = "decimal(6, 3)")]
        public required decimal Quantity { get; set; }
    }
}
