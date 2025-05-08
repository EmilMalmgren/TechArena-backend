using MongoDB.Driver;
using TechArena.Interfaces;

namespace TechArena.MongoDb.Repositories
{
    public class CommunityPantryRepository
    {
        private readonly IMongoCollection<ICommunityPantry> _collection;

        public CommunityPantryRepository(MongoDbContext context)
        {
            _collection = context.GetCollection<ICommunityPantry>("CommunityPantries");
        }

        public async Task<IEnumerable<ICommunityPantry>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<ICommunityPantry?> GetByIdAsync(string id) => await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ICommunityPantry pantry) => await _collection.InsertOneAsync(pantry);

        public async Task UpdateAsync(string id, ICommunityPantry pantry) => await _collection.ReplaceOneAsync(p => p.Id == id, pantry);

        public async Task DeleteAsync(string id) => await _collection.DeleteOneAsync(p => p.Id == id);
    }
}
