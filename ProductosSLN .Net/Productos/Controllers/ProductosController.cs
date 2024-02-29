using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Productos.Dto;
using Productos.Models;

namespace Productos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductoDbContext _context;

        public ProductosController(ProductoDbContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductosAllDto>>> GetProductos()
        {
            var productos = await _context.Productos
                               .Select(p => new ProductosAllDto
                               {
                                   Id = p.Id,
                                   Nombre = p.Nombre,
                                   Categoria = p.Categoria,
                                   Descripcion = p.Descripcion,
                                   Imagen = p.Imagen,
                               })
                               .ToListAsync();
            return productos;
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductosAllDto>> GetProductos(int id)
        {
            var productos = await _context.Productos
                                .Where(p => p.Id == id)
                               .Select(p => new ProductosAllDto
                               {
                                   Id = p.Id,
                                   Nombre = p.Nombre,
                                   Categoria = p.Categoria,
                                   Descripcion = p.Descripcion,
                                   Imagen = p.Imagen,
                               })
                                .FirstOrDefaultAsync();
            if (productos == null)
            {
                return NotFound();
            }

            return productos;
        }

        // PUT: api/Productos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // PUT: api/Productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductos(int id, ProductosDto productosDto)
        {
            if (id != productosDto.Id)
            {
                return BadRequest();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            producto.Nombre = productosDto.Nombre ?? producto.Nombre;
            producto.CategoriaId = productosDto.CategoriaId;
            producto.Descripcion = productosDto.Descripcion ?? producto.Descripcion;
            producto.Imagen = productosDto.Imagen ?? producto.Imagen;

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // POST: api/Productos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductosDto>> PostProductos(ProductosDto productosDto)
        {
            var producto = new Models.Productos
            {
                Nombre = productosDto.Nombre,
                CategoriaId = productosDto.CategoriaId,
                Descripcion = productosDto.Descripcion,
                Imagen = productosDto.Imagen,
                // Asegúrate de mapear cualquier otro campo necesario
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            // Luego, crea un objeto ProductosDto para devolver como respuesta
            var productoDto = new ProductosDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                CategoriaId = producto.CategoriaId,
                Descripcion = producto.Descripcion,
                Imagen = producto.Imagen,
                // Asegúrate de mapear cualquier otro campo necesario
            };

            // Devuelve un ActionResult con el objeto creado y la URI de la solicitud para obtenerlo
            return CreatedAtAction(nameof(GetProductos), new { id = productoDto.Id }, productoDto);
        }


        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductos(int id)
        {
            var productos = await _context.Productos.FindAsync(id);
            if (productos == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(productos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductosExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
        
    }
}
