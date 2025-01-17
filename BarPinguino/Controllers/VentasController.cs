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
    public class VentasController : Controller
    {
        private readonly AppDataContext _context;

        public VentasController(AppDataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Venta(string clienterut)
        {
            if (string.IsNullOrEmpty(clienterut)) 
            {
                ViewBag.Error = "Debe consultar un rut";
                return RedirectToAction("Consulta", "Registros");
            }
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
            if (string.IsNullOrEmpty(txtproducto) || txtcantidad == 0) return View();

            var producto = _context.Stocks.FirstOrDefault(p => p.NombreProducto == txtproducto);
            if (producto == null || producto.CantidadStock < txtcantidad)
            {
                ViewBag.Error = "Bebida agotada o no disponible";
                return View();
            }

            decimal precio = producto.Precio;
            decimal total = precio * txtcantidad;

            string guid32 = Guid.NewGuid().ToString("N");

            ViewBag.Producto = txtproducto;
            ViewBag.Precio = precio;
            ViewBag.Cantidad = txtcantidad;
            ViewBag.Total = total;
            ViewBag.rut = clienterut;
            ViewBag.guid = guid32;

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
                TotalDelPedido = TotalDelPedido
            };

            var productos = _context.Stocks.FirstOrDefault(p => p.NombreProducto == producto);

            productos.CantidadStock -= Cantidad;
            _context.Stocks.Update(productos);

            _context.Ventas.Add(venta);
            _context.SaveChanges();

            return View();
        }



    }
}
