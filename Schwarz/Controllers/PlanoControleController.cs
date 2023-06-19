using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schwarz.Data;

namespace Schwarz.Controllers
{
	public class PlanoControleController : Controller
	{
        private readonly SchwarzContext _context;

		public PlanoControleController(SchwarzContext context)
		{
			_context = context;
		}
        // GET: PlanoControleController1
        public ActionResult Index()
		{
			return View();
		}

		// GET: PlanoControleController1/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

        // GET: PlanoControleController1/Create
        public ActionResult Create()
		{
            ViewData["Funcionarios"] = new SelectList(_context.Funcionario.Where(x => x.Ativo), "IDFuncionario", "Nome");
            return View();
		}

		// POST: PlanoControleController1/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: PlanoControleController1/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: PlanoControleController1/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: PlanoControleController1/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: PlanoControleController1/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
