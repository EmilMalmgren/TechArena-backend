using Microsoft.AspNetCore.Mvc;
using TechArena.Interfaces;

namespace TechArena.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase
{
    private static readonly List<IRecipe> Recipes = new();

    [HttpGet]
    public IActionResult GetAll() => Ok(Recipes);

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var recipe = Recipes.FirstOrDefault(r => r.Id == id);
        return recipe is not null ? Ok(recipe) : NotFound();
    }

    [HttpPost]
    public IActionResult Create([FromBody] IRecipe recipe)
    {
        Recipes.Add(recipe);
        return CreatedAtAction(nameof(GetById), new { id = recipe.Id }, recipe);
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] IRecipe updatedRecipe)
    {
        var index = Recipes.FindIndex(r => r.Id == id);
        if (index == -1) return NotFound();
        Recipes[index] = updatedRecipe;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var recipe = Recipes.FirstOrDefault(r => r.Id == id);
        if (recipe is null) return NotFound();
        Recipes.Remove(recipe);
        return NoContent();
    }
}
