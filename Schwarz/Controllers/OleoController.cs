using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Schwarz.Models;

namespace Schwarz.Controllers
{
    public class OleoController : Controller
    {
        private readonly SchwarzContext _context;
        private readonly SignInManager<SchwarzUser> _signInManager;
        public OleoController(SchwarzContext context, SignInManager<SchwarzUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        [Authorize]
        public IActionResult Cadastrar()
        {
            CadastroOleo cadastroOleo = new(_context);
            return View(cadastroOleo);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            List<CadastroOleo> cadastroOleos = _context.CadastroOleo.ToList();
            var maquinas = _context.Maquina.ToList();
            return View(cadastroOleos);
        }

        [Authorize]
        public ActionResult CadastrarDados(CadastroOleo cadastroOleo)
        {
            try
            {
                cadastroOleo.Usuario = _signInManager.UserManager.GetUserId(User);
                _context.Add(cadastroOleo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro, por favor verifique os campos e tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Cadastrar");
            }
        }
    }
}
