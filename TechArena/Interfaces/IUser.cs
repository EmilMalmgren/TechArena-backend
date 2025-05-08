namespace TechArena.Interfaces
{
    public class IUser
    {
        public required int Id { get; init; }
        public List<IFridgeItem> FridgeItems { get; init; } = [];
    }
}
