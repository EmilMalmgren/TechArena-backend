namespace TechArena.Models;

public class Location
{
    public string Id { get; set; }
    public string Address { get; set; }
    public double Distance { get; set; }
    public IEnumerable<FridgeItem> Items { get; set; }
    public string Hours { get; set; }
    public string MapLink { get; set; }
}