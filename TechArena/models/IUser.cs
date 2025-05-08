namespace TechArena.Models
{
    public class IUser
    {
        public required int Id { get; init; }
        public List<FridgeItem> FridgeItems { get; init; } = [];
    }
}
