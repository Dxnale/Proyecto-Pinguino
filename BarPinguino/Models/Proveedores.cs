using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EVA2TI_BarPinguino.Models
{
    public class Proveedores
    {
        private string _rut;
        private string _giro;
        private string _razonSocial;
        private string _datosBanco;
        private int _fono;
        private string _direccion;
        private ICollection<Stock> _stocks;

        [Key]
        public string Rut
        {
            get => _rut;
            set => _rut = value;
        }

        [Required]
        public string Giro
        {
            get => _giro;
            set => _giro = value;
        }

        [Required]
        public string RazonSocial
        {
            get => _razonSocial;
            set => _razonSocial = value;
        }

        public string DatosBanco
        {
            get => _datosBanco;
            set => _datosBanco = value;
        }

        public int Fono
        {
            get => _fono;
            set => _fono = value;
        }

        public string Direccion
        {
            get => _direccion;
            set => _direccion = value;
        }

        public ICollection<Stock> Stocks
        {
            get => _stocks ??= new List<Stock>();
            set => _stocks = value;
        }
    }
}

