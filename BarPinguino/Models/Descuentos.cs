using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVA2TI_BarPinguino.Models
{
    public class Descuentos
    {
        private int _sku;
        private string _precioOriginal;
        private string _precioConDescuento;
        private Stock _stock;

        [Key]
        public int SKU
        {
            get => _sku;
            set => _sku = value;
        }

        public string PrecioOriginal
        {
            get => _precioOriginal;
            set => _precioOriginal = value;
        }

        public string PrecioConDescuento
        {
            get => _precioConDescuento;
            set => _precioConDescuento = value;
        }

        [ForeignKey("SKU")]
        public Stock Stock
        {
            get => _stock;
            set => _stock = value;
        }
    }
}
