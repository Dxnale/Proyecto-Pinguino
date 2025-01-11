using Microsoft.AspNetCore.Mvc;
using EVA2TI_BarPinguino.Models;
using Microsoft.Data.SqlClient;

namespace EVA2TI_BarPinguino.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IActionResult ViewIfIsRole(object? model = null, params string[] roles)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Taller");

            if (roles.Any(role => User.IsInRole(role)))
                return model == null ? View() : View(model);

            return RedirectToAction("Menu", "Home");
        }
    }
}
