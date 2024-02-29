using System.ComponentModel.DataAnnotations;

namespace Productos.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public String? Categorias { get; set; }

        //public ICollection<Productos>? Productos { get; set; }
    }
}
