using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Productos.Models
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }
        public  string? Nombre { get; set; }
        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        public string? Descripcion{ get; set; }
        public String? Imagen { get; set;}
      
        



    }
}
