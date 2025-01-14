using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EVA2TI_BarPinguino.Models
{
    public class Descuentos
    {
        [Key]
        public int SKU { get; set; }

        public string PrecioOriginal { get; set; }

        public string PrecioConDescuento { get; set; }

        [ForeignKey("SKU")]
        public Stock Stock { get; set; }
    }
}
