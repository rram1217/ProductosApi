using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductoFront.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatorio")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio")]
        public long Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
    }
}
