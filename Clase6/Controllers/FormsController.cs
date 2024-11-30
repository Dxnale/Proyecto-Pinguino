using Microsoft.AspNetCore.Mvc;

namespace Clase6.Controllers
{
    public class FormsController : Controller
    {
        public IActionResult Contacto()
        {
            return View();
        }
        public IActionResult SaveForm(string nom, string edad, string mail)
        {
            ViewBag.respuesta = nom;
            ViewBag.texto = "Respuesta a " + mail;
            return View("/Views/Forms/SaveForm.cshtml");
        }
    }
}
