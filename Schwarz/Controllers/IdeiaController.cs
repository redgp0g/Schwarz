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
		private readonly IIdeiaRepository _ideiaRepository;

		public IdeiaController(SchwarzContext contexto, SignInManager<SchwarzUser> signInManager, UserManager<SchwarzUser> userManager, IIdeiaRepository ideiaRepository)
		{
			_context = contexto;
			_signInManager = signInManager;
			_userManager = userManager;
			_ideiaRepository = ideiaRepository;

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
			var cadastropare = _context.Ideia.Find(id);
			if (cadastropare == null)
			{
				return NotFound();
			}
			return View(cadastropare);
		}

		[Authorize]
		public IActionResult Edit(int id)
		{
			var ideia = _context.Ideia.Find(id);
			if (ideia == null)
			{
				return NotFound();
			}
			return View(ideia);
		}

		public IActionResult Create()
		{
			Ideia ideia = new(_context);
			return View(ideia);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Cadastrar(Ideia ideia, List<int> Participantes)
		{
			try
			{
				ideia.Data = DateTime.Now;
				ideia.Status = "Recebida";
				ideia.IDUser = _signInManager.UserManager.GetUserId(User);
				using var transaction = _context.Database.BeginTransaction();
				try
				{

					_context.Add(ideia);
					foreach (var participante in Participantes)
					{
						EquipeIdeia equipeIdeia = new(participante, ideia.IDIdeia);
						_context.Add(equipeIdeia);
					}
					_context.SaveChanges();
					transaction.Commit();
					return RedirectToAction(nameof(Index));
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					TempData["Mensagem Erro"] = "Houve um erro, por favor tente novamente, detalhe do erro:" + ex.Message;
					return View("Create");
				}
			}
			catch (Exception ex)
			{
				TempData["Mensagem Erro"] = "Houve um erro, por favor tente novamente, detalhe do erro:" + ex.Message;
				return View("Create");
			}
		}


		public PartialViewResult PesquisarIdeia(string txtPesquisa, int? ano, string status)
		{
			IEnumerable<Ideia> model = _ideiaRepository.GetIdeias().OrderByDescending(x => x.Data);
			model = model.Where(x => x.Data.Year == (ano ?? DateTime.Now.Year));
			model = model.Where(x => x.Status == (status ?? x.Status));
			// Validate input parameters
			if (string.IsNullOrEmpty(txtPesquisa))
			{
				return PartialView("_GridView", model);
			}

			// Simplify search criteria
			txtPesquisa = txtPesquisa.ToLower();
			IEnumerable<Ideia> resultado = model.Where(x => $"{x.Descricao} {x.Status} {x.Ganho} {x.Investimento} {x.NomeEquipe} {x.Data.ToString()} {string.Join(" ", x.EquipeIdeia.Select(e => e.Funcionario.Nome))}".ToLower().Contains(txtPesquisa)).ToList();

			return PartialView("_GridView", resultado);
		}


		public List<string> GetFuncionariosNomes()
		{
			var funcs = _context.Funcionario.Where(x => x.Ativo == true).OrderBy(x => x.Nome).ToList();
			List<string> nomes = new();
			foreach (var func in funcs)
			{
				nomes.Add(func.Nome);
			}
			return nomes;
		}

		public List<int> GetFuncionariosIDs()
		{
			var funcs = _context.Funcionario.Where(x => x.Ativo == true).OrderBy(x => x.Nome).ToList();
			List<int> ids = new();
			foreach (var func in funcs)
			{
				ids.Add(func.IDFuncionario);
			}
			return ids;
		}
	}
}