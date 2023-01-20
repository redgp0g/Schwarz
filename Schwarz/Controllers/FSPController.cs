using Microsoft.AspNetCore.Mvc;
using Schwarz.Data;
using Schwarz.Models;

namespace Schwarz.Controllers
{
    public class FSPController : Controller
    {
        private readonly SchwarzContext _context;
        public FSPController(SchwarzContext contexto)
        {
            _context = contexto;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            FSP fSP = new(_context);
            return View(fSP);
        }

        public ActionResult Cadastrar(FSP fSP)
        {
            return View("Index");
        }
    }
}
