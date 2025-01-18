using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVA2TI_BarPinguino.Models
{
    public class Venta
    {
        private string _numBoleta;
        private int _credencialVendedor;
        private string _detalles;
        private string _clienteRut;
        private decimal _totalDelPedido;
        private Usuarios _usuario;
        private Clientes _cliente;

        [Key]
        public string NumBoleta
        {
            get => _numBoleta;
            set => _numBoleta = value;
        }

        [Required]
        public int CredencialVendedor
        {
            get => _credencialVendedor;
            set => _credencialVendedor = value;
        }

        [Required]
        public string Detalles
        {
            get => _detalles;
            set => _detalles = value;
        }

        [Required]
        public string ClienteRut
        {
            get => _clienteRut;
            set => _clienteRut = value;
        }

        public decimal TotalDelPedido
        {
            get => _totalDelPedido;
            set => _totalDelPedido = value;
        }

        [ForeignKey("CredencialVendedor")]
        public Usuarios Usuario
        {
            get => _usuario;
            set => _usuario = value;
        }

        [ForeignKey("ClienteRut")]
        public Clientes Cliente
        {
            get => _cliente;
            set => _cliente = value;
        }
    }
}
