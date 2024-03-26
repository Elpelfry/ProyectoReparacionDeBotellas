using HydraulicFix.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;

namespace HydraulicFix.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController(IServerAsp<IdentityRole> _service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<IdentityRole>>> Get()
    {
        return await _service.GetAllObject();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IdentityRole>> Get(string id)
    {
        var user = await _service.GetObject(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }

    [HttpPost]
    public async Task<ActionResult<IdentityRole>> Post(IdentityRole user)
    {
        var newuser = await _service.AddObject(user);
        return CreatedAtAction(nameof(Get), new { id = newuser.Id }, newuser);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, IdentityRole user)
    {
        if (id != user.Id)
        {
            return BadRequest();
        }
        await _service.UpdateObject(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _service.DeleteObject(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
