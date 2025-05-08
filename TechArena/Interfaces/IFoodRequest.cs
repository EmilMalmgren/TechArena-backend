namespace TechArena.Interfaces;

public interface IFoodRequest
{
    string Id { get; set; }
    string UserInitial { get; set; }
    string UserName { get; set; }
    string UserColor { get; set; }
    IEnumerable<IFridgeItem> Items { get; set; }
    string Location { get; set; }
    string TimePosted { get; set; }
    string TimeNeededBy { get; set; }
    FoodRequestStatus Status { get; set; }
    string? Description { get; set; }
    double Distance { get; set; }
}

