using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EVA2TI_BarPinguino.Controllers.Maestro
{
    public class MaestroController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Menu()
        {
            return View();
        }
    }
}
