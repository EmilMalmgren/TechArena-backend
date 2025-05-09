namespace TechArena.Models;

public class FridgeItem
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public string Unit { get; set; }
    public DateOnly ExpiryDate { get; set; }
    public bool Reserved {get;set;}
}