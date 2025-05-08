namespace TechArena.Interfaces;

public interface ICommunityPantry
{
    int Id { get; set; }
    int UserId { get; set; }
    string Name { get; set; }
    string Type { get; set; }
    string Address { get; set; }
    double Distance { get; set; }
    IEnumerable<IFridgeItem> Items { get; set; }
    string Hours { get; set; }
    string DaysOpen { get; set; }
}
