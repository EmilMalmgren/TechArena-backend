using Microsoft.AspNetCore.Mvc;
using TechArena.Interfaces;

namespace TechArena.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodRequestController : ControllerBase
{
    private static readonly List<IFoodRequest> FoodRequests = new();

    [HttpGet]
    public IActionResult GetAll() => Ok(FoodRequests);

    [HttpGet("{id}")]
    public IActionResult GetById(string id)
    {
        var request = FoodRequests.FirstOrDefault(r => r.Id == id);
        return request is not null ? Ok(request) : NotFound();
    }

    [HttpPost]
    public IActionResult Create([FromBody] IFoodRequest request)
    {
        FoodRequests.Add(request);
        return CreatedAtAction(nameof(GetById), new { id = request.Id }, request);
    }

    [HttpPut("{id}")]
    public IActionResult Update(string id, [FromBody] IFoodRequest updatedRequest)
    {
        var index = FoodRequests.FindIndex(r => r.Id == id);
        if (index == -1) return NotFound();
        FoodRequests[index] = updatedRequest;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var request = FoodRequests.FirstOrDefault(r => r.Id == id);
        if (request is null) return NotFound();
        FoodRequests.Remove(request);
        return NoContent();
    }
}
