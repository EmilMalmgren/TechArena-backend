using Microsoft.AspNetCore.Mvc;
using TechArena.Interfaces;

namespace TechArena.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FridgeItemController : ControllerBase
{
    private static readonly List<IFridgeItem> FridgeItems = new();

    [HttpGet]
    public IActionResult GetAll() => Ok(FridgeItems);

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var item = FridgeItems.FirstOrDefault(i => i.Id == id);
        return item is not null ? Ok(item) : NotFound();
    }

    [HttpPost]
    public IActionResult Create([FromBody] IFridgeItem item)
    {
        FridgeItems.Add(item);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] IFridgeItem updatedItem)
    {
        var index = FridgeItems.FindIndex(i => i.Id == id);
        if (index == -1) return NotFound();
        FridgeItems[index] = updatedItem;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var item = FridgeItems.FirstOrDefault(i => i.Id == id);
        if (item is null) return NotFound();
        FridgeItems.Remove(item);
        return NoContent();
    }
}
