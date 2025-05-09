using Microsoft.AspNetCore.Mvc;
using TechArena.Models;
using TechArena.MongoDb.Repositories;

namespace TechArena.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly LocationRepository _repository;

    public LocationController(LocationRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var item = await _repository.GetByIdAsync(id);
        return item is not null ? Ok(item) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Location location)
    {
        await _repository.CreateAsync(location);
        return CreatedAtAction(nameof(GetById), new { id = location.Id }, location);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] Location updatedLocation)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null) return NotFound();
        await _repository.UpdateAsync(id, updatedLocation);
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
