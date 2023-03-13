using Microsoft.AspNetCore.Mvc;

namespace ProjLibreriaAPI.Controllers
{
    public class UtenteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
