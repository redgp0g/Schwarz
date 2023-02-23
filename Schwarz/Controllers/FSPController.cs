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

        public ActionResult Cadastrar(FSP fSP, List<int> EquipeMultiFuncional, List<int> Numeros, List<string> Acoes, List<int> Responsaveis, List<DateTime> Prazos, List<string> Status)
        {

            for(int i = 1; i< Numeros.Count; i++)
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
