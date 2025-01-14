using System.ComponentModel.DataAnnotations;

namespace EVA2TI_BarPinguino.Models
{
    public class Finanzas
    {
        [Key]
        public string InformeDeStock { get; set; }

        public string Fecha { get; set; }

        public decimal Gasto { get; set; }

        public string Ingreso { get; set; }

        public string Detalles { get; set; }

        public string NDocumento { get; set; }

        public string TipoDeDocumento { get; set; }
    }
}
