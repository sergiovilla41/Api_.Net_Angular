using Productos.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Productos.Dto
{
    public class ProductosAllDto
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }       
        public Categoria? Categoria { get; set; }
        public string? Descripcion { get; set; }
        public String? Imagen { get; set; }
    }
}
