using Microsoft.AspNetCore.Mvc;
using TechArena.Models;
using TechArena.MongoDb.Repositories;

namespace TechArena.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase
{
    private readonly FridgeItemRepository _fridgeItemRepository;
    private readonly RecipeRepository _recipeRepository;

    public RecipeController(RecipeRepository repository, FridgeItemRepository fridgeItemRepository)
    {
        _recipeRepository = repository;
        _fridgeItemRepository = fridgeItemRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _recipeRepository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var recipe = await _recipeRepository.GetByIdAsync(id);
        return recipe is not null ? Ok(recipe) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] IRecipe recipe)
    {
        await _recipeRepository.CreateAsync(recipe);
        return CreatedAtAction(nameof(GetById), new { id = recipe.Id }, recipe);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] IRecipe updatedRecipe)
    {
        var existing = await _recipeRepository.GetByIdAsync(id);
        if (existing is null) return NotFound();
        await _recipeRepository.UpdateAsync(id, updatedRecipe);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var existing = await _recipeRepository.GetByIdAsync(id);
        if (existing is null) return NotFound();
        await _recipeRepository.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> SuggestRecipe()
    {
        var recipies = await _recipeRepository.GetAllAsync();
        if (recipies is null) return NotFound();
        var fridgeItems = await _fridgeItemRepository.GetAllAsync();
        if (fridgeItems is null) return NotFound();

        foreach (var recipe in recipies)
        {
            foreach (var ingredient in recipe.Ingredients)
            {
                if(fridgeItems.Any(i => i.Name == ingredient.Name))
                    recipe.MatchedIngredients.Add(ingredient);              
                else
                    recipe.MissingIngredients.Add(ingredient);
            }
        }
        return Ok(recipies);
    }
}
