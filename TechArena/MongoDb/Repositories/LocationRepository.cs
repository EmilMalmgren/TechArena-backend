using MongoDB.Driver;
using TechArena.Models;

namespace TechArena.MongoDb.Repositories;

public class LocationRepository
{
    private readonly IMongoCollection<Location> _collection;

    public LocationRepository(MongoDbContext context)
    {
        _collection = context.GetCollection<Location>("Locations");
    }

    public async Task<IEnumerable<Location>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

    public async Task<Location?> GetByIdAsync(string id) => await _collection.Find(i => i.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Location item) => await _collection.InsertOneAsync(item);

    public async Task UpdateAsync(string id, Location item) => await _collection.ReplaceOneAsync(i => i.Id == id, item);

    public async Task AddItemAsync(string id, FridgeItem item){
         var filter = Builders<Location>.Filter.Eq(loc => loc.Id, id);
        var update = Builders<Location>.Update.Push(loc => loc.Items, item);

        await _collection.UpdateOneAsync(filter, update);
    }

    public async Task DeleteAsync(string id) => await _collection.DeleteOneAsync(i => i.Id == id);
}
