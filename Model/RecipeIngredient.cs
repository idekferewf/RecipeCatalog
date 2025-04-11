using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeCatalog.Model
{
    public class RecipeIngredient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимо указать рецепт.")]
        public int RecipeId { get; set; }

        [ForeignKey("RecipeId")]
        public Recipe Recipe { get; set; }

        [Required(ErrorMessage = "Необходимо указать ингредиент.")]
        public int IngredientId { get; set; }

        [ForeignKey("IngredientId")]
        public Ingredient Ingredient { get; set; }

        [Required(ErrorMessage = "Необходимо указать количество ингредиента.")]
        [Column(TypeName = "decimal(6, 3)")]
        public decimal Quantity { get; set; }
    }
}
