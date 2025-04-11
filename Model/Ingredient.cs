using System.ComponentModel.DataAnnotations;

namespace RecipeCatalog.Model
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимо указать название ингредиента.")]
        [StringLength(255, ErrorMessage = "Максимальная длина названия ингредиента - 255 символов.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Необходимо указать единицу измерения ингредиента.")]
        [StringLength(30, ErrorMessage = "Максимальная длина единицы измерения ингредиента - 30 символов.")]
        public string Unit { get; set; }

        public List<RecipeIngredient> RecipeIngredients { get; set; } = [];
    }
}
