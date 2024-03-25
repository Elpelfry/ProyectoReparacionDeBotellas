using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Interfaces;

namespace HydraulicFix.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProveedoresController(IHydraulic<Proveedores> _service) : ControllerBase
{
    // GET: api/Proveedores
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Proveedores>>> GetProveedores()
    {
        return await _service.GetAllObject();
    }

    // GET: api/Proveedores/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Proveedores>> GetProveedores(int id)
    {
        var proveedores = await _service.GetObject(id);

        if (proveedores == null)
        {
            return NotFound();
        }

        return proveedores;
    }

    // POST: api/Proveedores
    [HttpPost]
    public async Task<ActionResult<Proveedores>> PostProveedores(Proveedores proveedores)
    {
        var pro = await _service.AddObject(proveedores);
        return CreatedAtAction(nameof(GetProveedores), new { id = pro.ProveedorId }, pro);
    }

    // PUT: api/Proveedores/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProveedores(int id, Proveedores proveedores)
    {
        if (id != proveedores.ProveedorId)
        {
            return BadRequest();
        }

        await _service.UpdateObject(proveedores);
        return NoContent();
    }

    // DELETE: api/Proveedores/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProveedores(int id)
    {
        var proveedores = await _service.DeleteObject(id);
        if (!proveedores)
        {
            return NotFound();
        }
        return NoContent();
    }
}
