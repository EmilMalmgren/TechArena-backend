namespace TechArena.Interfaces;

public interface IRecipe
{
    string Id { get; set; }
    string Name { get; set; }
    string Image { get; set; }
    int PrepTime { get; set; }
    IEnumerable<string> Ingredients { get; set; }
    IEnumerable<string> MatchedIngredients { get; set; }
    IEnumerable<string> MissingIngredients { get; set; }
    RecipeDifficulty Difficulty { get; set; }
    double Rating { get; set; }
    IEnumerable<string> Instructions { get; set; }
    string Category { get; set; }
}
