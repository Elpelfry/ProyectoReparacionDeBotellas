using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Interfaces;

namespace HydraulicFix.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReparacionesController(IHydraulic<Reparaciones> _service) : ControllerBase
{
    // GET: api/Reparaciones
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reparaciones>>> GetReparaciones()
    {
        return await _service.GetAllObject();
    }

    // GET: api/Reparaciones/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Reparaciones>> GetReparaciones(int id)
    {
        var reparaciones = await _service.GetObject(id);

        if (reparaciones == null)
        {
            return NotFound();
        }

        return reparaciones;
    }

    // POST: api/Reparaciones
    [HttpPost]
    public async Task<ActionResult<Reparaciones>> PostReparaciones(Reparaciones reparaciones)
    {
        var repa = await _service.AddObject(reparaciones);
        return CreatedAtAction(nameof(GetReparaciones), new { id = repa.ReparacionId }, repa);
    }

    // PUT: api/Reparaciones/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutReparaciones(int id, Reparaciones reparaciones)
    {
        if (id != reparaciones.ReparacionId)
        {
            return BadRequest();
        }
        await _service.UpdateObject(reparaciones);
        return NoContent();
    }

    // DELETE: api/Reparaciones/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReparaciones(int id)
    {
        var reparaciones = await _service.DeleteObject(id);
        if (!reparaciones)
        {
            return NotFound();
        }
        return NoContent();
    }
}
