using Microsoft.AspNetCore.Mvc;

namespace EVA2TI_BarPinguino.Controllers
{
    public class FormsController : BaseController
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
