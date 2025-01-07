using System.ComponentModel.DataAnnotations.Schema;

namespace EVA2TI_BarPinguino.Models
{
    public class Finanzas
    {
        public string Informe_stock { get; set; }
        [ForeignKey("Inferme_stock")]
        public virtual Stock Stock { get; set; }
        public string Fecha { get; set; }
        public int Gasto { get; set; }
        public string ingreso { get; set; }
        public string Detalles { get; set; }
        public string n_documento { get; set; }
        [ForeignKey("Num_Boleta")]
        public virtual Venta Venta { get; set; }
        public string tipo_documento { get; set; }
    }
}
