using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;

namespace HydraulicFix.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserRolesController(IHydraulicAsp<IdentityUserRole<string>> _service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<IdentityUserRole<string>>>> Get()
    {
        return await _service.GetAllObject();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IdentityUserRole<string>>> Get(string id)
    {
        var user = await _service.GetObject(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }

    [HttpPost]
    public async Task<ActionResult<IdentityUserRole<string>>> Post(IdentityUserRole<string> use)
    {
       var user =  await _service.AddObject(use);
       return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, IdentityUserRole<string> user)
    {
        if (id != user.UserId)
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
