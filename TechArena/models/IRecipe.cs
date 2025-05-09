namespace TechArena.Models;

public interface IRecipe
{
    string Id { get; set; }
    string Name { get; set; }
    string Image { get; set; }
    int PrepTime { get; set; }
    IEnumerable<FridgeItem> Ingredients { get; set; }
    List<FridgeItem> MatchedIngredients { get; set; }
    List<FridgeItem> MissingIngredients { get; set; }
    RecipeDifficulty Difficulty { get; set; }
    double Rating { get; set; }
    IEnumerable<string> Instructions { get; set; }
    string Category { get; set; }
}
