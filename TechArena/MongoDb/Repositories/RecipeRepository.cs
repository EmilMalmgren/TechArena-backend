using MongoDB.Driver;
using TechArena.Interfaces;

namespace TechArena.MongoDb.Repositories;

public class RecipeRepository
{
    private readonly IMongoCollection<IRecipe> _collection;

    public RecipeRepository(MongoDbContext context)
    {
        _collection = context.GetCollection<IRecipe>("Recipes");
    }

    public async Task<IEnumerable<IRecipe>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

    public async Task<IRecipe?> GetByIdAsync(string id) => await _collection.Find(r => r.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(IRecipe recipe) => await _collection.InsertOneAsync(recipe);

    public async Task UpdateAsync(string id, IRecipe recipe) => await _collection.ReplaceOneAsync(r => r.Id == id, recipe);

    public async Task DeleteAsync(string id) => await _collection.DeleteOneAsync(r => r.Id == id);
}
