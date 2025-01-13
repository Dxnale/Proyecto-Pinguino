using EVA2TI_BarPinguino.Models;
using EVA2TI_BarPinguino.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EVA2TI_BarPinguino.Controllers
{
    public class RegistrosController : Controller
    {
        private readonly AppDataContext _context;
        public RegistrosController(AppDataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult RegistroUserEmpleado()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserRegistrado(Usuarios usuario)
        {
            var newUser = new Usuarios
            {
                Credencial_vendedor = usuario.Credencial_vendedor,
                clave = usuario.clave,
                Nombre = usuario.Nombre,
                TipoDeUsuario = usuario.TipoDeUsuario
            };
            _context.Usuarios.Add(newUser);
            _context.SaveChanges();

            return View("UserRegistrado", usuario);
        }
        [HttpGet]
        public IActionResult RegistrarUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrado(Clientes clientes)
        {

            var newuser = new Clientes
            {
                Rut = clientes.Rut,
                Nombre = clientes.Nombre,
                Apellido = clientes.Apellido,
                Frecuente = clientes.Frecuente
            };
            _context.Clientes.Add(newuser);
            _context.SaveChanges();


            return View("Registrado", clientes);
        }

        [HttpGet]
        public IActionResult Consulta()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Consulta(string txtRut)
        {
            var cl = _context.Clientes.FirstOrDefault(c => c.Rut == txtRut);
            if (cl != null)
            {
                ViewBag.ShowModal = true;
                return View(cl);
            }

            return View();
        }
        

    }
}
