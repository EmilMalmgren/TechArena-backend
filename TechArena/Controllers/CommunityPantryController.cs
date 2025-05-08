using Microsoft.AspNetCore.Mvc;
using TechArena.Interfaces;
using TechArena.MongoDb.Repositories;

namespace TechArena.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommunityPantryController : ControllerBase
{
    private readonly CommunityPantryRepository _repository;

    public CommunityPantryController(CommunityPantryRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var pantry = await _repository.GetByIdAsync(id);
        return pantry is not null ? Ok(pantry) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ICommunityPantry pantry)
    {
        await _repository.CreateAsync(pantry);
        return CreatedAtAction(nameof(GetById), new { id = pantry.Id }, pantry);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] ICommunityPantry updatedPantry)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null) return NotFound();
        await _repository.UpdateAsync(id, updatedPantry);
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
