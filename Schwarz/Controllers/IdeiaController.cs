using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Microsoft.AspNetCore.Http;
using Schwarz.Models;
using Schwarz.Repository;
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
		private readonly IWebHostEnvironment _hostingEnvironment;

		public IdeiaController(SchwarzContext contexto, SignInManager<SchwarzUser> signInManager, UserManager<SchwarzUser> userManager, IIdeiaRepository ideiaRepository, IWebHostEnvironment hostingEnvironment)
		{
			_context = contexto;
			_signInManager = signInManager;
			_userManager = userManager;
			_ideiaRepository = ideiaRepository;
			_hostingEnvironment = hostingEnvironment;

		}

		[HttpGet]
		public IActionResult Index()
		{
			var ideia = _context.Ideia.Include(x => x.EquipeIdeia).ToList().OrderByDescending(x => x.Data);
			return View(ideia);
		}

		public PartialViewResult BuscarIdeias()
		{

			IEnumerable<Ideia> model = _ideiaRepository.GetIdeias().OrderByDescending(x => x.Data);
			return PartialView("_GridViewIdeias", model);

		}

		[HttpGet]
		public async Task<IActionResult> Details(int? id)
		{

			if (id == null || _context.Ideia == null)
			{
				return NotFound();
			}
			var ideia = await _context.Ideia.FindAsync(id);
			if (ideia == null)
			{
				return NotFound();
			}
			return View(ideia);
		}

		[HttpGet]
		[Authorize(Roles = "IdeiaAdmin")]
		public IActionResult Edit(int id)
		{
			ViewData["Funcionarios"] = new SelectList(_context.Funcionario.Where(x => x.Ativo), "IDFuncionario", "Nome");
			var ideia = _context.Ideia.Find(id);
			if (ideia == null)
			{
				return NotFound();
			}
			return View(ideia);
		}


		[HttpPost]
		[Authorize(Roles = "IdeiaAdmin")]
		public async Task<IActionResult> Edit(Ideia ideia)
		{
			try
			{
				_context.Update(ideia);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			catch (DbUpdateConcurrencyException)
			{
				return View(ideia);
			}

		}
		[HttpGet]
		public IActionResult Create()
		{
			ViewData["Funcionarios"] = new SelectList(_context.Funcionario.Where(x => x.Ativo), "IDFuncionario", "Nome");
			return View();
		}

		[HttpPost]
		public IActionResult Create(Ideia ideia, List<IFormFile> files)
		{
			try
			{
				ideia.Data = DateTime.Now;
				ideia.Status = "Recebida";
				using var transaction = _context.Database.BeginTransaction();

				try
				{
					_context.Add(ideia);
					_context.SaveChanges();
					foreach (var participante in ideia.Participantesids)
					{
						EquipeIdeia equipeIdeia = new(participante, ideia.IDIdeia);
						_context.Add(equipeIdeia);
						_context.SaveChanges();
					}
					// Verifique se existem arquivos
					if (files != null && files.Count > 0)
					{
						foreach (var file in files)
						{
							// Verifique o tamanho do arquivo (opcional)
							if (file.Length > 0)
							{
								// Leia o conteúdo do arquivo em um array de bytes
								using (var memoryStream = new MemoryStream())
								{
									file.CopyTo(memoryStream);
									byte[] fileBytes = memoryStream.ToArray();

									string tipoMime = file.ContentType;
									string fileName = file.FileName;

									IdeiaAnexo ideiaAnexo = new(fileName, fileBytes, tipoMime, ideia.IDIdeia);
									_context.Add(ideiaAnexo);
									_context.SaveChanges();
									// Atribua o conteúdo do arquivo à propriedade Anexo
								}
							}
						}
					}
					transaction.Commit();
					return RedirectToAction(nameof(Index));
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					TempData["MensagemErro"] = "Houve um erro, por favor tente novamente, detalhe do erro:" + ex.Message;
					ViewData["Funcionarios"] = new SelectList(_context.Funcionario.Where(x => x.Ativo), "IDFuncionario", "Nome");
					return View(ideia);
				}
			}
			catch (Exception ex)
			{
				TempData["MensagemErro"] = "Houve um erro, por favor tente novamente, detalhe do erro:" + ex.Message;
				return RedirectToAction("Create");
			}
		}


		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.FSP == null)
			{
				return NotFound();
			}

			var ideia = await _context.Ideia
				.FirstOrDefaultAsync(m => m.IDIdeia == id);
			if (ideia == null)
			{
				return NotFound();
			}

			return View(ideia);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "IdeiaAdmin")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Ideia == null)
			{
				return Problem("Entity set 'SchwarzContext.FSP'  is null.");
			}
			var ideia = await _context.Ideia.FindAsync(id);
			using var transaction = _context.Database.BeginTransaction();
			try
			{
				if (ideia != null)
				{
					foreach (var equipe in ideia.EquipeIdeia)
					{
						_context.EquipeIdeia.Remove(equipe);
					}
					foreach (var anexo in ideia.IdeiaAnexo)
					{
						_context.IdeiaAnexo.Remove(anexo);
					}
					_context.Ideia.Remove(ideia);
				}

				await _context.SaveChangesAsync();
				transaction.Commit();
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				transaction.Rollback();
				TempData["MensagemErro"] = "Houve um erro ao deletar, detalhes do erro" + ex.Message;
				return RedirectToAction(nameof(Index));
			}

		}

		public class Player
		{
			public string Nome { get; set; }
			public int Points { get; set; }
			public Player(string nome, int points)
			{
				Nome = nome;
				Points = points;

			}
		}
		IEnumerable<Player> players = new List<Player>{
		   new Player ("Guilherme", new Random().Next(0,100)),
		   new Player ("Andre", new Random().Next(0,100)),
		   new Player ("Rafa", new Random().Next(0,100)),
		   new Player ("Gilvania", new Random().Next(0,100)),
		   new Player ("Jhonatan", new Random().Next(0,100)),
		   new Player ("Camile", new Random().Next(0,100)),
		   new Player ("Wesley", new Random().Next(0,100))
		};
		public IActionResult Ranking()
		{
			return View(players.OrderByDescending(x => x.Points));
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

		[HttpPost]
		public IActionResult DeletarParticipante(int id)
		{
			var participante = _context.EquipeIdeia.Find(id);
			if (participante != null)
			{
				_context.EquipeIdeia.Remove(participante);
				_context.SaveChanges();
				return Ok();
			}
			return NotFound();
		}

		[HttpPost]
		public IActionResult AdicionarParticipante(int idFuncionario, int idideia)
		{
			var func = _context.Funcionario.Find(idFuncionario);
			if (func != null)
			{
				bool equipeIdeiaExistente = _context.EquipeIdeia.Any(ei => ei.IDFuncionario == func.IDFuncionario && ei.IDIdeia == idideia);
				if (equipeIdeiaExistente)
				{
					return Conflict("Já existe esse participante na equipe!");
				}

				EquipeIdeia equipeIdeia = new(func.IDFuncionario, idideia);
				_context.EquipeIdeia.Add(equipeIdeia);
				_context.SaveChanges();

				var result = new
				{
					idEquipe = equipeIdeia.IDEquipeIdeia,
					nome = func.Nome
				};

				return Ok(result);

			}
			return NotFound();
		}
		[HttpPost]
		public IActionResult AdicionarAnexo(IFormFileCollection files, int idideia)
		{
			try
			{
				foreach (var file in files)
				{
					// Leia o conteúdo do arquivo em um array de bytes
					using (var memoryStream = new MemoryStream())
					{
						file.CopyTo(memoryStream);
						byte[] fileBytes = memoryStream.ToArray();

						string tipoMime = file.ContentType;
						string fileName = file.FileName;

						IdeiaAnexo ideiaAnexo = new(fileName, fileBytes, tipoMime, idideia);
						_context.Add(ideiaAnexo);
						_context.SaveChanges();
					}
				}
				return Ok();
			}

			catch (Exception ex)
			{
				return Json(new
				{
					error = "Ocorreu um erro ao adicionar o anexo: " + ex.Message
				});
			}
		}

		[HttpPost]
		public IActionResult RemoverAnexo(int id)
		{
			var anexo = _context.IdeiaAnexo.Find(id);
			if (anexo != null)
			{
				_context.IdeiaAnexo.Remove(anexo);
				_context.SaveChanges();
				return Ok();
			}
			return NotFound();
		}
	}
}