namespace TechArena.Interfaces;

public interface IFridgeItem
{
    string Id { get; set; }
    string Name { get; set; }
    string Category { get; set; }
    int Quantity { get; set; }
    string Unit { get; set; }
    DateOnly ExpiryDate { get; set; }
}