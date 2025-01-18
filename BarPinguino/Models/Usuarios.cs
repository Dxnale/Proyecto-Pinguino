using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EVA2TI_BarPinguino.Models
{
    public class Usuarios
    {
        private int _credencialVendedor;
        private string _clave;
        private string _nombre;
        private string _correo;
        private string _tipoUsuario;
        private ICollection<Venta> _ventas;

        [Key]
        public int CredencialVendedor
        {
            get => _credencialVendedor;
            set => _credencialVendedor = value;
        }

        [Required]
        public string Clave
        {
            get => _clave;
            set => _clave = value;
        }

        [Required]
        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        [Required]
        [MaxLength(100)]
        public string Correo
        {
            get => _correo;
            set => _correo = value;
        }

        [Required]
        public string TipoUsuario
        {
            get => _tipoUsuario;
            set => _tipoUsuario = value;
        }

        public ICollection<Venta> Ventas
        {
            get => _ventas ??= new List<Venta>();
            set => _ventas = value;
        }
    }
}

