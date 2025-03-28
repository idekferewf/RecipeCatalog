using System.ComponentModel.DataAnnotations;

namespace RecipeCatalog.Model
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимо указать название ингредиента.")]
        [StringLength(255, ErrorMessage = "Название ингредиента не должно превышать 255 символов.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Необходимо указать единицу измерения ингредиента.")]
        [StringLength(30, ErrorMessage = "Единица измерения не должна превышать 30 символов.")]
        public required string Unit { get; set; }

        [Required]
        public required List<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
