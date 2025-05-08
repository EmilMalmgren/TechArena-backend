using Microsoft.AspNetCore.Mvc;
using TechArena.Interfaces;
using TechArena.MongoDb.Repositories;

namespace TechArena.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodRequestController : ControllerBase
{
    private readonly FoodRequestRepository _repository;

    public FoodRequestController(FoodRequestRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var request = await _repository.GetByIdAsync(id);
        return request is not null ? Ok(request) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] IFoodRequest request)
    {
        await _repository.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = request.Id }, request);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] IFoodRequest updatedRequest)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null) return NotFound();
        await _repository.UpdateAsync(id, updatedRequest);
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
