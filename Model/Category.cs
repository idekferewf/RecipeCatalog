using System.ComponentModel.DataAnnotations;

namespace RecipeCatalog.Model
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public required string Name { get; set; }

        [Required]
        public required List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
