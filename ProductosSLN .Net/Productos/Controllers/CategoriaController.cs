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
    public class CategoriaController : ControllerBase
    {
        private readonly ProductoDbContext _context;

        public CategoriaController(ProductoDbContext context)
        {
            _context = context;
        }

        // GET: api/Imagens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetImagen()
        {
            var categoria = await _context.Categoria
                              .Select(p => new CategoriaDto
                              {
                                  Id = p.Id,
                                  Categorias = p.Categorias,
                              })
                              .ToListAsync();
            return categoria;
        }

        // GET: api/Imagens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDto>> GetCategoria(int id)
        {
            var categorias = await _context.Categoria
                               .Where(p => p.Id == id)
                              .Select(p => new CategoriaDto
                              {
                                  Id = p.Id,
                                  Categorias = p.Categorias,
                              })
                               .FirstOrDefaultAsync();
            if (categorias == null)
            {
                return NotFound();
            }

            return categorias;
        }

        // PUT: api/Imagens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, CategoriaDto categoriaDto)
        {
            if (id != categoriaDto.Id)
            {
                return BadRequest();
            }

            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            categoria.Id = categoriaDto.Id;
            categoria.Categorias = categoriaDto.Categorias ?? categoria.Categorias;

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagenExists(id))
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

        // POST: api/Imagens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoriaDto>> PostCategoria(CategoriaDto categoriaDto)
        {
            var categoria = new Models.Categoria
            {
                Categorias = categoriaDto.Categorias
                
            };

            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();

            // Luego, crea un objeto ProductosDto para devolver como respuesta
            var categoriasDto = new CategoriaDto
            {
                Categorias = categoria.Categorias
                // Asegúrate de mapear cualquier otro campo necesario
            };

            // Devuelve un ActionResult con el objeto creado y la URI de la solicitud para obtenerlo
            return CreatedAtAction(nameof(PostCategoria), new { id = categoria.Id }, categoriaDto);
        }

        // DELETE: api/Imagens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImagen(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImagenExists(int id)
        {
            return _context.Categoria.Any(e => e.Id == id);
        }
    }
}
