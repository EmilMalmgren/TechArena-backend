namespace TechArena.Models;

public interface ICommunityPantry
{
    string Id { get; set; }
    string Name { get; set; }
    string Type { get; set; }
    string Address { get; set; }
    double Distance { get; set; }
    IEnumerable<FridgeItem> Items { get; set; }
    string Hours { get; set; }
    string DaysOpen { get; set; }
}
