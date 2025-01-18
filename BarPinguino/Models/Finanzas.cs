using System.ComponentModel.DataAnnotations;

namespace EVA2TI_BarPinguino.Models
{
    public class Finanzas
    {
        private string _informeDeStock;
        private string _fecha;
        private decimal _gasto;
        private string _ingreso;
        private string _detalles;
        private string _nDocumento;
        private string _tipoDeDocumento;

        [Key]
        public string InformeDeStock
        {
            get => _informeDeStock;
            set => _informeDeStock = value;
        }

        public string Fecha
        {
            get => _fecha;
            set => _fecha = value;
        }

        public decimal Gasto
        {
            get => _gasto;
            set => _gasto = value;
        }

        public string Ingreso
        {
            get => _ingreso;
            set => _ingreso = value;
        }

        public string Detalles
        {
            get => _detalles;
            set => _detalles = value;
        }

        public string NDocumento
        {
            get => _nDocumento;
            set => _nDocumento = value;
        }

        public string TipoDeDocumento
        {
            get => _tipoDeDocumento;
            set => _tipoDeDocumento = value;
        }
    }
}
