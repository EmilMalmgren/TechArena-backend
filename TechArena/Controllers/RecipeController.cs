using Microsoft.AspNetCore.Mvc;
using TechArena.Interfaces;
using TechArena.MongoDb.Repositories;

namespace TechArena.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase
{
    private readonly RecipeRepository _repository;

    public RecipeController(RecipeRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var recipe = await _repository.GetByIdAsync(id);
        return recipe is not null ? Ok(recipe) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] IRecipe recipe)
    {
        await _repository.CreateAsync(recipe);
        return CreatedAtAction(nameof(GetById), new { id = recipe.Id }, recipe);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] IRecipe updatedRecipe)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null) return NotFound();
        await _repository.UpdateAsync(id, updatedRecipe);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null) return NotFound();
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
