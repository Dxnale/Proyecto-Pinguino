using System.ComponentModel.DataAnnotations;

namespace EVA2TI_BarPinguino.Models
{
    public class Clientes
    {
        [Key]
        public string Rut { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        public string Frecuente { get; set; }

        public ICollection<Venta> Ventas { get; set; }
    }
}
