using Productos.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Productos.Dto
{
    public class ProductosDto
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }       
        public int CategoriaId { get; set; }      
        public string? Descripcion { get; set; }
        public String? Imagen { get; set; }
    }
}