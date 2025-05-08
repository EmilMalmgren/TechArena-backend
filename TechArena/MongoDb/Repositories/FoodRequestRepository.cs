using MongoDB.Driver;
using TechArena.Interfaces;

namespace TechArena.MongoDb.Repositories;

public class FoodRequestRepository
{
    private readonly IMongoCollection<IFoodRequest> _collection;

    public FoodRequestRepository(MongoDbContext context)
    {
        _collection = context.GetCollection<IFoodRequest>("FoodRequests");
    }

    public async Task<IEnumerable<IFoodRequest>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

    public async Task<IFoodRequest?> GetByIdAsync(string id) => await _collection.Find(r => r.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(IFoodRequest request) => await _collection.InsertOneAsync(request);

    public async Task UpdateAsync(string id, IFoodRequest request) => await _collection.ReplaceOneAsync(r => r.Id == id, request);

    public async Task DeleteAsync(string id) => await _collection.DeleteOneAsync(r => r.Id == id);
}
