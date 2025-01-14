using System.ComponentModel.DataAnnotations;

namespace EVA2TI_BarPinguino.Models
{
    public class Proveedores
    {
        [Key]
        public string Rut { get; set; }

        [Required]
        public string Giro { get; set; }

        [Required]
        public string RazonSocial { get; set; }

        public string DatosBanco { get; set; }

        public int Fono { get; set; }

        public string Direccion { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }
}
