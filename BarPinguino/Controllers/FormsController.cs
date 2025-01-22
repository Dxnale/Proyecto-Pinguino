using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;

namespace EVA2TI_BarPinguino.Controllers
{
    public class FormsController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();
        [HttpPost]

        public IActionResult Contacto()
        {
            return View();
        }

        public IActionResult Mesapi()
        {
            return View("Mesas");
        }
        public IActionResult SaveForm(string nom, string edad, string mail)
        {
            ViewBag.respuesta = nom;
            ViewBag.texto = "Respuesta a " + mail;
            return View("/Views/Forms/SaveForm.cshtml");
        }
    }
}
