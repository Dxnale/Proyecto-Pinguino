using System.ComponentModel.DataAnnotations;

namespace EVA2TI_BarPinguino.Models
{
    public class Stock
    {
        [Key]
        public int SKU { get; set; }

        [Required]
        public string Proveedor { get; set; }

        public int CantidadStock { get; set; }

        public int StockCritico { get; set; }

        public decimal Precio { get; set; }

        public string InformeDeStock { get; set; }

        public Proveedores ProveedorNavigation { get; set; }
    }
}
