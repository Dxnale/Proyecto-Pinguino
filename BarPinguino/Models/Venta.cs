using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVA2TI_BarPinguino.Models
{
    public class Venta
    {
        [Key]
        public string NumBoleta { get; set; }

        [Required]
        public int CredencialVendedor { get; set; }

        [Required]
        public string Detalles { get; set; }

        [Required]
        public string ClienteRut { get; set; }

        public decimal TotalDelPedido { get; set; }

        [ForeignKey("CredencialVendedor")]
        public Usuarios Usuario { get; set; }

        [ForeignKey("ClienteRut")]
        public Clientes Cliente { get; set; }
    }
}
