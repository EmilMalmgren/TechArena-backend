using MongoDB.Driver;
using TechArena.Interfaces;

namespace TechArena.MongoDb.Repositories;

public class FridgeItemRepository
{
    private readonly IMongoCollection<IFridgeItem> _collection;

    public FridgeItemRepository(MongoDbContext context)
    {
        _collection = context.GetCollection<IFridgeItem>("FridgeItems");
    }

    public async Task<IEnumerable<IFridgeItem>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

    public async Task<IFridgeItem?> GetByIdAsync(string id) => await _collection.Find(i => i.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(IFridgeItem item) => await _collection.InsertOneAsync(item);

    public async Task UpdateAsync(string id, IFridgeItem item) => await _collection.ReplaceOneAsync(i => i.Id == id, item);

    public async Task DeleteAsync(string id) => await _collection.DeleteOneAsync(i => i.Id == id);
}
