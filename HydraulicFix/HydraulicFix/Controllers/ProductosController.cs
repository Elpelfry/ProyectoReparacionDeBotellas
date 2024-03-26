using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using Shared.Interfaces;

namespace HydraulicFix.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductosController(IServer<Productos> _service) : ControllerBase
{
    // GET: api/Productos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Productos>>> GetProductos()
    {
        return await _service.GetAllObject();
    }

    // GET: api/Productos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Productos>> GetProductos(int id)
    {
        var productos = await _service.GetObject(id);

        if (productos == null)
        {
            return NotFound();
        }

        return productos;
    }

    // POST: api/Productos
    [HttpPost]
    public async Task<ActionResult<Productos>> PostProductos(Productos productos)
    {
        var product = await _service.AddObject(productos);
        return CreatedAtAction(nameof(GetProductos), new { id = product.ProductoId }, product);
    }

    // PUT: api/Productos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProductos(int id, Productos productos)
    {
        if (id != productos.ProductoId)
        {
            return BadRequest();
        }
        await _service.UpdateObject(productos);
        return NoContent();
    }

    // DELETE: api/Productos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductos(int id)
    {
        var productos = await _service.DeleteObject(id);
        if (!productos)
        {
            return NotFound();
        }
        return NoContent();
    }
}
