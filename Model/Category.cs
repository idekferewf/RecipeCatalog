using System.ComponentModel.DataAnnotations;

namespace RecipeCatalog.Model
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимо указать название категории.")]
        [StringLength(255, ErrorMessage = "Максимальная длина названия категории - 255 символов.")]
        public string Name { get; set; }

        public List<Recipe> Recipes { get; set; } = [];
    }
}
