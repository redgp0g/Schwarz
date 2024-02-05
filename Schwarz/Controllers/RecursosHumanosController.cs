using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Schwarz.Models;

namespace Schwarz.Controllers
{
    public class RecursosHumanosController : Controller
    {

        private readonly SchwarzContext _context;
        private readonly UserManager<SchwarzUser> _userManager;


        public RecursosHumanosController(SchwarzContext context, UserManager<SchwarzUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Ramais()
        {
            List<Funcionario> ramais = _context.Funcionario.Where(x => x.Ativo && x.Ramal != null).Select(x => new Funcionario { Nome = x.Nome, Ramal = x.Ramal, Setor = x.Setor }).ToList();
            return View(ramais);
        }

        public IActionResult Aniversariantes()
        {
            List<Funcionario> ramais = _context.Funcionario.Where(x => x.Ativo).Select(x => new Funcionario { Nome = x.Nome, DataNascimento = x.DataNascimento }).ToList();
            return View(ramais);
        }
    }
}
