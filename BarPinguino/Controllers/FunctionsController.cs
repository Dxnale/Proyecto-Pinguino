using System;
using System.Net.Mail;
using EVA2TI_BarPinguino.Data;
using EVA2TI_BarPinguino.Models;
using EVA2TI_BarPinguino.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;

namespace EVA2TI_BarPinguino.Controllers
{
    public class FunctionsController : Controller
    {
        private readonly AppDataContext _context;
        private readonly Correo _correo;

        // Inyecta el contexto en el controlador
        public FunctionsController(AppDataContext context, Correo correo)
        {
            _correo = correo;
            _context = context;
        }

        [Authorize(Roles ="Admin, Ventas, Stock")]
        public IActionResult DatosInventario()
        {
            // Obtén todos los productos
            var productos = _context.Stocks.ToList();

            // Listas para almacenar productos según su cantidad en stock
            var productosCriticos = new List<Stock>();
            var productosAceptables = new List<Stock>();
            var productosNuevos = new List<Stock>();

            // Recorremos cada producto para verificar CantidadStock
            foreach (var producto in productos)
            {
                // Si el stock es menor a 10 litros, lo agregamos a productos críticos
                if (producto.CantidadStock/1000.0 < 10)
                {
                    productosCriticos.Add(producto);
                }
                // Si el stock está entre 10 y 50 litros, lo agregamos a productos aceptables
                else if (producto.CantidadStock / 1000.0 < 50)
                {
                    productosAceptables.Add(producto);
                }
                // Si el stock es mayor o igual a 50 litros, lo agregamos a productos nuevos
                else
                {
                    productosNuevos.Add(producto);
                }
            }


            // Guardamos las listas en ViewBag para ser usadas en la vista
            ViewBag.ProductosCriticos = productosCriticos;
            ViewBag.ProductosAceptables = productosAceptables;
            ViewBag.ProductosNuevos = productosNuevos;

            return View();  // Retorna la vista
        }

        public IActionResult DatosPreparacion()
        {
            // Obtén todos los productos
            var productosVenta = _context.Ventas.Where(v => v.EnPreparacion).ToList();

            // Pasa los datos al ViewBag
            ViewBag.ProductosVenta = productosVenta;

            return View();
        }
        public IActionResult DatosProcedimiento(int numero)
        {
            // Obtén todos los productos en preparación
            var productosEnPreparacion = _context.Ventas.Where(v => v.EnPreparacion).ToList();

            // Si se recibe un parámetro válido
            if (numero > 0 && numero <= productosEnPreparacion.Count)
            {
                // Obtiene el producto seleccionado
                var productoSeleccionado = productosEnPreparacion[numero - 1];
                
                // Cambia el estado a false
                productoSeleccionado.EnPreparacion = false;
                
                // Actualiza el producto en la base de datos
                _context.Ventas.Update(productoSeleccionado);
                _context.SaveChanges();

                return View("/Views/Functions/Procedimiento.cshtml");
            }

            // Pasa los datos al ViewBag
            ViewBag.ProductosVenta = productosEnPreparacion;

            return View("/Views/Functions/Inventario.cshtml");
        }




        [Authorize(Roles = "Stock, Admin")]
        public IActionResult Preparacion()
        {
            DatosPreparacion();
            return View("/Views/Functions/Preparacion.cshtml");
        }
        [Authorize(Roles = "Stock, Admin")]
        public IActionResult datosCerrados(int i)
        {
            DatosProcedimiento(i);
            return View();
        }
        [Authorize(Roles = "Stock, Admin")]
        public IActionResult Procedimiento()
        {
            DatosPreparacion();
            return View();
        }

        [Authorize(Roles = "Stock, Admin")]
        public IActionResult Inventario()
        {
            DatosInventario();
            return View("/Views/Functions/Inventario.cshtml");
        }
        [Authorize(Roles = "Stock, Admin")]
        public IActionResult Restock()
        {
            return View("/Views/Functions/Restock.cshtml");
        }
        [Authorize(Roles = "Stock, Admin")]
        public IActionResult CorreoProveedores(string productos,int cantidad,string proveedor)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.CredencialVendedor == 111);
            if (string.IsNullOrEmpty(productos) && (cantidad == 0) && string.IsNullOrEmpty(proveedor))
            {
                _correo.EnvMail(usuario!.Correo, "REESTOCK PRODUCTOS CRITICOS", $@"
        <body style='text-align: center;'>
            <div>
                <h1 style='color:#f39c12;font-family:sans-serif; text-align: center;'>FALTA DE INSUMOS Y/O STOCK.</h1>
                <p style='color:#f39c12;font-family:sans-serif; text-align: center;'>INFORMO SOBRE FALTA DE STOCK, SE SOLICITA STOCK DE ABSOLUTAMENTE TODOS LOS PRODUCTOS CRITICOS, POR FAVOR REVISAR INVENTARIO</p>
            </div>
        </body>");
            }
            else
            {
                _correo.EnvMail(usuario!.Correo, "REESTOCK PRODUCTOS CRITICOS", $@"
        <body style='text-align: center;'>
            <div>
                <h1 style='color:#f39c12;font-family:sans-serif; text-align: center;'>FALTA DE INSUMOS Y/O STOCK.</h1>
                <p style='color:#f39c12;font-family:sans-serif; text-align: center;'>INFORMO SOBRE FALTA DE STOCK, SE SOLICITA STOCK DE LOS SIGUIENTES PRODUCTOS CRITICOS {productos} , POR FAVOR REVISAR INVENTARIO</p>
            </div>
        </body>");
            }

            return View("/Views/Functions/CorreoProveedores.cshtml");
        }
    }
}