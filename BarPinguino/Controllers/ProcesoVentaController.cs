using Microsoft.AspNetCore.Mvc;
using EVA2TI_BarPinguino.Models;
using EVA2TI_BarPinguino.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;


namespace EVA2TI_BarPinguino.Controllers
{
    [Authorize(Roles = "Admin,Ventas")]
    public class ProcesoVentaController : Controller
    {
        private readonly AppDataContext _context;
        private static int incremento;

        public ProcesoVentaController(AppDataContext context)
        {
            _context = context;
            if(incremento == 0)
                incremento = _context.Ventas.Count();
        }
        [HttpGet]
        public IActionResult Venta(string clienterut)
        {
            if (string.IsNullOrEmpty(clienterut))
            {
                ViewBag.Error = "Debe consultar un rut";
                return RedirectToAction("Consulta", "Registros");
            }
            var productosDisponibles = _context.Stocks.Where(p => p.CantidadStock > 10).ToList();
            ViewBag.ProductosDisponibles = productosDisponibles;
            ViewBag.rut = clienterut;
            return View();
        }
        [HttpPost]
        public IActionResult Venta(string clienterut, string txtproducto, int txtcantidad)
        {
            if (string.IsNullOrEmpty(clienterut))
            {
                ViewBag.Error = "Debe consultar un rut";
                return RedirectToAction("Consulta", "Registros");
            }

            var credencial = User.FindFirst("CredencialVendedor")!.Value;

            var productosDisponibles = _context.Stocks.Where(p => p.CantidadStock > 10).ToList();
            

            if (string.IsNullOrEmpty(txtproducto) || txtcantidad == 0) return View();

            var producto = _context.Stocks.FirstOrDefault(p => p.NombreProducto == txtproducto);
            if (producto == null || producto.CantidadStock < txtcantidad)
            {
                ViewBag.Error = "Bebida agotada o no disponible";
                ViewBag.ProductosDisponibles = _context.Stocks.Where(p => p.CantidadStock > 10).ToList();
                ViewBag.rut = clienterut;
                return View();
            }

            decimal precio = producto.Precio;
            decimal total = precio * txtcantidad;

            var descuento = _context.Descuentos.FirstOrDefault(d => d.SKU == producto.SKU);
            decimal descuentoAplicado = 0;

            if (descuento != null && !string.IsNullOrEmpty(descuento.PrecioConDescuento))
            {
                decimal precioConDescuento;
                if (decimal.TryParse(descuento.PrecioConDescuento, out precioConDescuento))
                {
                    descuentoAplicado = (precio - precioConDescuento) * txtcantidad;
                    total = precioConDescuento * txtcantidad;
                }
            }

            ++incremento;

            ViewBag.Producto = txtproducto;
            ViewBag.Precio = precio;
            ViewBag.Cantidad = txtcantidad;
            ViewBag.Total = total;
            ViewBag.rut = clienterut;
            ViewBag.guid = incremento;
            ViewBag.descuento = descuentoAplicado;
            ViewBag.product = producto.SKU;
            ViewBag.ProductosDisponibles = productosDisponibles;

            return View();
        }

        public IActionResult Boleta(string NumBoleta, int CredencialVendedor, string Detalles, string ClienteRut, decimal TotalDelPedido, string producto, int Cantidad)
        {
            var venta = new Venta
            {
                NumBoleta = NumBoleta,
                CredencialVendedor = CredencialVendedor,
                Detalles = Detalles,
                ClienteRut = ClienteRut,
                TotalDelPedido = TotalDelPedido,
                Fecha = DateOnly.FromDateTime(DateTime.Now),
                EnPreparacion = true
            };
            var productos = _context.Stocks.FirstOrDefault(p => p.NombreProducto == producto);

            productos.CantidadStock -= Cantidad;
            _context.Stocks.Update(productos);

            _context.Ventas.Add(venta);
            _context.SaveChanges();

            ViewBag.Vendedor = CredencialVendedor;
            ViewBag.Cliente = ClienteRut;
            ViewBag.Boleta = NumBoleta;
            ViewBag.Productos = new List<dynamic>
    {
            new { Nombre = producto, Cantidad }
    };
            ViewBag.Total = TotalDelPedido;

            return View();
        }
    }
}
