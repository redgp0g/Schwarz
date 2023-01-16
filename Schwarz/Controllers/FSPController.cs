using Microsoft.AspNetCore.Mvc;

namespace Schwarz.Controllers
{
    public class FSPController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
