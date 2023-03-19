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
			var fsps = _context.FSP.ToList();
			return View(fsps);
		}
		public IActionResult Create()
		{
			FSP fSP = new(_context);
			return View(fSP);
		}

		public IActionResult Details(int? id)
		{
			if (id == null || _context.Ideia == null)
			{
				return NotFound();
			}
			var fsp = _context.FSP.Find(id);
			if (fsp == null)
			{
				return NotFound();
			}
			return View(fsp);
		}

		public ActionResult Cadastrar(FSP fSP, List<int> EquipeMultiFuncional, List<int> Numeros, List<string> Acoes, List<int> Responsaveis, List<DateTime> Prazos, List<string> Status)
		{
			fSP.DataAbertura = DateTime.Now;

			using var transaction = _context.Database.BeginTransaction();
			try
			{
				_context.Add(fSP);
				_context.SaveChanges();
				foreach (int idfuncionario in EquipeMultiFuncional)
				{
					EquipeFSP equipeFSP = new()
					{
						IDFuncionario = idfuncionario,
						IDFSP = fSP.IDFSP
					};
					_context.Add(equipeFSP);
					_context.SaveChanges();

				}
				for (int i = 0; i < Numeros.Count; i++)
				{
					PlanoAcao planoAcao = new()
					{
						IDFSP = fSP.IDFSP,
						Descricao = Acoes[i],
						Status = Status[i],
						Prazo = Prazos[i],
						IDFuncionario = Responsaveis[i]
					};
					_context.Add(planoAcao);
					_context.SaveChanges();
				}
				_context.SaveChanges();
				transaction.Commit();
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				transaction.Rollback();
				TempData["MensagemErro"] = "Houve um erro, por favor tente novamente, detalhe do erro:" + ex.Message;
				return RedirectToAction("Create");
			}
		}

		[HttpPost]
		public ActionResult Editar(FSP fSP, List<int> EquipeMultiFuncional, List<int> Numeros, List<string> Acoes, List<int> Responsaveis, List<DateTime> Prazos, List<string> Status)
		{

			for (int i = 1; i < Numeros.Count; i++)
			{

			}

			fSP.DataAbertura = DateTime.Now;
			_context.Add(fSP);
			foreach (int idfuncionario in EquipeMultiFuncional)
			{
				EquipeFSP equipeFSP = new()
				{
					IDFuncionario = idfuncionario,
					IDFSP = fSP.IDFSP
				};
				_context.Add(equipeFSP);

			}
			_context.SaveChanges();
			return View("Index");
		}
	}
}
