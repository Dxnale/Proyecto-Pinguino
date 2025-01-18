using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EVA2TI_BarPinguino.Models
{
    public class Clientes
    {
        private string _rut;
        private string _nombre;
        private string _apellido;
        private string _frecuente;
        private ICollection<Venta> _ventas;

        [Key]
        public string Rut
        {
            get => _rut;
            set => _rut = value;
        }

        [Required]
        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        [Required]
        public string Apellido
        {
            get => _apellido;
            set => _apellido = value;
        }

        public string Frecuente
        {
            get => _frecuente;
            set => _frecuente = value;
        }

        public ICollection<Venta> Ventas
        {
            get => _ventas ??= new List<Venta>();
            set => _ventas = value;
        }
    }
}
