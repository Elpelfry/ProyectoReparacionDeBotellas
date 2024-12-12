using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Interfaces;

namespace HydraulicFix.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AbonosController(IServer<Abonos> _service) : ControllerBase
{
    // GET: api/Abonos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Abonos>>> GetAbonos()
    {
        return await _service.GetAllObject();
    }

    // GET: api/Abonos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Abonos>> GetAbonos(int id)
    {
        var abonos = await _service.GetObject(id);

        if (abonos == null)
        {
            return NotFound();
        }

        return abonos;
    }

    // POST: api/Abonos
    [HttpPost]
    public async Task<ActionResult<Abonos>> PostAbonos(Abonos abono)
    {
        var abonos = await _service.AddObject(abono);
        return CreatedAtAction(nameof(GetAbonos), new { id = abonos.AbonoId }, abonos);
    }

    // PUT: api/Abonos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAbonos(int id, Abonos abonos)
    {
        if (id != abonos.AbonoId)
        {
            return BadRequest();
        }
        await _service.UpdateObject(abonos);

        return NoContent();
    }

    // DELETE: api/Abonos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAbonos(int id)
    {
        var abonos = await _service.DeleteObject(id);
        if (!abonos)
        {
            return NotFound();
        }

        return NoContent();
    }
}
