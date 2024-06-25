using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class AjaxPersonaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
