using MongoDB.Driver;
using TechArena.Interfaces;

namespace TechArena.MongoDb.Repositories
{
    public class UserRepository
    {
        private readonly IMongoCollection<IUser> _collection;

        public UserRepository(MongoDbContext context)
        {
            _collection = context.GetCollection<IUser>("CommunityPantries");
        }

        public async Task<IEnumerable<IUser>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<IUser?> GetByIdAsync(int id) => await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(IUser pantry) => await _collection.InsertOneAsync(pantry);

        public async Task UpdateAsync(int id, IUser pantry) => await _collection.ReplaceOneAsync(p => p.Id == id, pantry);

        public async Task DeleteAsync(int id) => await _collection.DeleteOneAsync(p => p.Id == id);
    }
}
