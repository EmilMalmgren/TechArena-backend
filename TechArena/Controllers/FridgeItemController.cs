using Microsoft.AspNetCore.Mvc;
using TechArena.Interfaces;
using TechArena.MongoDb.Repositories;

namespace TechArena.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FridgeItemController : ControllerBase
{
    private readonly UserRepository _repository;

    public FridgeItemController(UserRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _repository.GetByIdAsync(id);
        return item is not null ? Ok(item) : NotFound();
    }

    [HttpPost("{userId}")]
    public async Task<IActionResult> AddItem(int userId, [FromBody] IFridgeItem item)
    {
        var user = await _repository.GetByIdAsync(userId);
        return user is not null ? Ok(user.FridgeItems) : NotFound();
    }

    [HttpDelete("{userId}/{id]")]
    public async Task<IActionResult> DeleteItem(int userId, int id)
    {
        var user = await _repository.GetByIdAsync(userId);
        if(user is null) return NotFound();
        var item = user.FridgeItems.FirstOrDefault(i => i.Id == id);
        if (item is null) return NotFound();
        user.FridgeItems.Remove(item);
        return Ok();
    }
}
