using System.ComponentModel.DataAnnotations.Schema;

namespace EVA2TI_BarPinguino.Models
{
    public class Venta
    {
        public string Num_Boleta { get; set; }
        public int Credencial_v { get; set; }
        [ForeignKey("Credencial_vendedor")]
        public virtual Usuarios Usuarios { get; set; }
        public string Detalles { get; set; }
        public string cliente_rut { get; set; }
        [ForeignKey("Rut")]
        public virtual Clientes Clientes { get; set; }
        public int TotalPedido { get; set; }
        public virtual ICollection<Finanzas> Finanzas { get; set; }
    }
}
