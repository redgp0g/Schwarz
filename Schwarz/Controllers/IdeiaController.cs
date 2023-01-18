using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Schwarz.Models;
using Schwarz.Repository.Interfaces;
using System.Diagnostics;

namespace ProgramaIdeias.Controllers
{
	public class IdeiaController : Controller
	{
        private readonly UserManager<SchwarzUser> _userManager;
        private readonly SignInManager<SchwarzUser> _signInManager;
        private readonly SchwarzContext _context;
		private readonly IBaseRepository _baseRepository;

		public IdeiaController(SchwarzContext contexto, SignInManager<SchwarzUser> signInManager, UserManager<SchwarzUser> userManager, IBaseRepository baseRepository)
		{
			_context = contexto;
			_signInManager = signInManager;
			_userManager= userManager;
			_baseRepository= baseRepository;

		}

		[HttpGet]
		public IActionResult Index()
		{
			Ideia ideia = new(_context);
			return View(ideia);
		}

		public async Task<IActionResult> Details(int? id)
		{

			if (id == null || _context.Ideia == null)
			{
				return NotFound();
			}

			var cadastropare = _context.Ideia.FirstOrDefault(m => m.IDIdeia == id);
			if (cadastropare == null)
			{
				return NotFound();
			}
			return View(cadastropare);
		}

		[Authorize]
		public IActionResult Leaderboard()
		{
			return View();
		}

		[Authorize]
		public IActionResult Create()
		{
			Ideia ideia = new(_context);
			return View(ideia);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Cadastrar(Ideia ideia, List<int> Participantes)
		{
			try
			{
				ideia.Data = DateTime.Now;
				ideia.Status = "Em Processo";
				ideia.Ganho ??= "Não identificado";
                ideia.Investimento ??= "Não identificado";
                ideia.IDUser = _signInManager.UserManager.GetUserId(User);
				_context.Add(ideia);
				_context.SaveChanges();
				foreach (var participante in Participantes)
				{
					EquipeIdeia equipeIdeia = new(participante, ideia.IDIdeia);
					_context.Add(equipeIdeia);
					_context.SaveChanges();//Verificar como funciona o SaveChanges e considerar possível melhoria de desempenho
				}
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				TempData["Mensagem Erro"] = "Houve um erro, por favor tente novamente, detalhe do erro:" + ex.Message;
				return View("Create", ideia);
			}
		}

		public PartialViewResult PesquisarIdeia(string txtPesquisa)
		{
			var model = _baseRepository.GetIdeias().OrderByDescending(x => x.Data);
			if (txtPesquisa != null)
			{
				txtPesquisa = txtPesquisa.ToLower();
				IEnumerable<Ideia> resultado = model.Where(x => x.Descricao.ToLower().Contains(txtPesquisa) || x.Status.ToString().Contains(txtPesquisa) || x.Ganho.ToLower().Contains(txtPesquisa) || x.Data.ToString().Contains(txtPesquisa) || (x.Investimento != null && x.Investimento.ToLower().Contains(txtPesquisa)) || (x.NomeEquipe != null && x.NomeEquipe.ToLower().Contains(txtPesquisa)) || (x.Feedback != null && x.Feedback.ToLower().Contains(txtPesquisa)) || x.EquipeIdeia.Any(x => x.Funcionario.Nome.ToLower().Contains(txtPesquisa)) ).ToList();
				return PartialView("_GridView", resultado);
			}
			return PartialView("_GridView", model);

		}
	}
}