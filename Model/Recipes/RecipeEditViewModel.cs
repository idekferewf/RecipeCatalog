namespace RecipeCatalog.Model.Recipes;

public class RecipeEditViewModel
{
    public required Recipe Recipe { get; set; }
    public List<Category> Categories { get; set; } = [];
}