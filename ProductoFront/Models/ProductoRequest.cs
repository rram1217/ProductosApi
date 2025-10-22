using System.ComponentModel.DataAnnotations;

namespace ProductoFront.Models
{
    public class ProductoRequest
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatorio")]
        public string Descripcion { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
        public decimal Precio { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Today;
        public bool Estado { get; set; }
    }
}
