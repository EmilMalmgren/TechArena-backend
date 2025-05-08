using Microsoft.AspNetCore.Mvc;
using TechArena.Interfaces;

namespace TechArena.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommunityPantryController : ControllerBase
{
    private static readonly List<ICommunityPantry> CommunityPantries = new();

    [HttpGet]
    public IActionResult GetAll() => Ok(CommunityPantries);

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var pantry = CommunityPantries.FirstOrDefault(p => p.Id == id);
        return pantry is not null ? Ok(pantry) : NotFound();
    }

    [HttpPost]
    public IActionResult Create([FromBody] ICommunityPantry pantry)
    {
        CommunityPantries.Add(pantry);
        return CreatedAtAction(nameof(GetById), new { id = pantry.Id }, pantry);
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] ICommunityPantry updatedPantry)
    {
        var index = CommunityPantries.FindIndex(p => p.Id == id);
        if (index == -1) return NotFound();
        CommunityPantries[index] = updatedPantry;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var pantry = CommunityPantries.FirstOrDefault(p => p.Id == id);
        if (pantry is null) return NotFound();
        CommunityPantries.Remove(pantry);
        return NoContent();
    }
}
