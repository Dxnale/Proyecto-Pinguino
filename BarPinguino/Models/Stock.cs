using System.ComponentModel.DataAnnotations.Schema;

namespace EVA2TI_BarPinguino.Models
{
    public class Stock
    {
        public int Sku { get; set; }
        [ForeignKey("Sku")]
        public virtual Descuentos Descuentos { get; set; }
        public string Provedor { get; set; }
        [ForeignKey("Provedor")]
        public virtual Proveedores Proveedores { get; set; }
        public int stock { get; set; }
        public int Stock_critico { get; set; }
        public int precio { get; set; }
        public string Informe_stock { get; set; }
        public virtual ICollection<Finanzas> Finanzas { get; set; }

    }
}
