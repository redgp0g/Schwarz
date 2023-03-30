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
			var equipes = _context.EquipeIdeia.ToList();

			var ideia = _context.Ideia.ToList().OrderByDescending(x => x.Data);
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

		[Authorize(Roles = "IdeiaADM")]
		public IActionResult Edit(int id)
		{
			var ideia = _context.Ideia.Find(id);
			if (ideia == null)
			{
				return NotFound();
			}
			return View(ideia);
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
		public ActionResult Create(Ideia ideia, List<int> Participantes)
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
					_context.SaveChanges();
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
					return RedirectToAction("Create");
				}
			}
			catch (Exception ex)
			{
				TempData["Mensagem Erro"] = "Houve um erro, por favor tente novamente, detalhe do erro:" + ex.Message;
				return RedirectToAction("Create");
			}
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