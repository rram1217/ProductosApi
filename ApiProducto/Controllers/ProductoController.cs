using ApiProducto.Database;
using ApiProducto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProducto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _context.Producto.OrderBy(x => x.Precio).ToListAsync();
            if (result == null || result.Count == 0)
            {
                return NotFound(new { message = "No existen productos." });
            }
            return Ok(result);
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _context.Producto.SingleOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return NotFound(new { message = "No existe producto." });
            }
            return Ok(result);
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto producto)
        {
            await _context.Producto.AddAsync(producto);
            await _context.SaveChangesAsync();
            return Ok(producto);
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Producto producto)
        {
            var existingProd = await _context.Producto.SingleOrDefaultAsync(x => x.Id == id);
            if (existingProd == null)
            {
                return NotFound(new { message = "Producto no encontrado." });
            }
            existingProd.Nombre = producto.Nombre;
            existingProd.Descripcion = producto.Descripcion;
            existingProd.Precio = producto.Precio;
            existingProd.Estado = producto.Estado;
            _context.Producto.Update(existingProd);
            await _context.SaveChangesAsync();
            return Ok(existingProd);
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingTask = await _context.Producto.SingleOrDefaultAsync(x => x.Id == id);
            if (existingTask == null)
            {
                return NotFound(new { message = "Producto no encontrado" });
            }
            _context.Producto.Remove(existingTask);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Task deleted successfully." });
        }
    }
}
