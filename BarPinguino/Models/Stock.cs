using System.ComponentModel.DataAnnotations;

namespace EVA2TI_BarPinguino.Models
{
    public class Stock
    {
        private int _sku;
        private string _nombreProducto;
        private string _proveedor;
        private int _cantidadStock;
        private int _stockCritico;
        private decimal _precio;
        private string _informeDeStock;
        private Proveedores _proveedorNavigation;

        [Key]
        public int SKU
        {
            get => _sku;
            set => _sku = value;
        }

        [Required]
        [MaxLength(50)]
        public string NombreProducto
        {
            get => _nombreProducto;
            set => _nombreProducto = value;
        }

        [Required]
        public string Proveedor
        {
            get => _proveedor;
            set => _proveedor = value;
        }

        public int CantidadStock
        {
            get => _cantidadStock;
            set => _cantidadStock = value;
        }

        public int StockCritico
        {
            get => _stockCritico;
            set => _stockCritico = value;
        }

        public decimal Precio
        {
            get => _precio;
            set => _precio = value;
        }

        public string InformeDeStock
        {
            get => _informeDeStock;
            set => _informeDeStock = value;
        }

        public Proveedores ProveedorNavigation
        {
            get => _proveedorNavigation;
            set => _proveedorNavigation = value;
        }
    }
}
