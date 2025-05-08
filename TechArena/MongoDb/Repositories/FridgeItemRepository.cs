using MongoDB.Driver;
using TechArena.Models;

namespace TechArena.MongoDb.Repositories;

public class FridgeItemRepository
{
    private readonly IMongoCollection<FridgeItem> _collection;

    public FridgeItemRepository(MongoDbContext context)
    {
        _collection = context.GetCollection<FridgeItem>("FridgeItems");
    }

    public async Task<IEnumerable<FridgeItem>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

    public async Task<FridgeItem?> GetByIdAsync(string id) => await _collection.Find(i => i.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(FridgeItem item) => await _collection.InsertOneAsync(item);

    public async Task UpdateAsync(string id, FridgeItem item) => await _collection.ReplaceOneAsync(i => i.Id == id, item);

    public async Task DeleteAsync(string id) => await _collection.DeleteOneAsync(i => i.Id == id);
}
