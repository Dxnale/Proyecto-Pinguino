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

    }
}
