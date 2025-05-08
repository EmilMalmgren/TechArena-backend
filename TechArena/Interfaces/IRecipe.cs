namespace TechArena.Interfaces;

public interface IRecipe
{
    string Id { get; set; }
    string Name { get; set; }
    string Image { get; set; }
    int PrepTime { get; set; }
    IEnumerable<IFridgeItem> Ingredients { get; set; }
    IEnumerable<IFridgeItem> MatchedIngredients { get; set; }
    IEnumerable<IFridgeItem> MissingIngredients { get; set; }
    RecipeDifficulty Difficulty { get; set; }
    double Rating { get; set; }
    IEnumerable<string> Instructions { get; set; }
    string Category { get; set; }
}
