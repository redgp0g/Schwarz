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
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProgramaIdeias.Controllers
{
    public class IdeiaController : Controller
    {
        private readonly UserManager<SchwarzUser> _userManager;
        private readonly SignInManager<SchwarzUser> _signInManager;
        private readonly SchwarzContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public IdeiaController(SchwarzContext contexto, SignInManager<SchwarzUser> signInManager, UserManager<SchwarzUser> userManager, IWebHostEnvironment hostingEnvironment)
        {
            _context = contexto;
            _signInManager = signInManager;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet]
        public IActionResult Index(int? idfuncionario)
        {
            return View(idfuncionario);
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var anoAtual = DateTime.Now.Year;
            ViewBag.QuantidadesPorMes = _context.Ideia
            .Where(x => x.Data.Year == anoAtual)
            .GroupBy(x => x.Data.Month)
            .Select(group => new { Mes = group.Key, Quantidade = group.Count() })
            .OrderBy(x => x.Mes)
            .ToList();

            ViewBag.Meses = new string[]
            {
        "Jan", "Fev", "Mar", "Abr", "Mai", "Jun",
        "Jul", "Ago", "Set", "Out", "Nov", "Dez"
            };

            //calculo de quanto em porcentagem aumentou a quantidade de ideias desse ano comparado com o ano anterior
            var totalIdeiasAnoAnterior = _context.Ideia.Where(x => x.Data.Year == anoAtual - 1).Count();
            var totalIdeiasAnoAtual = _context.Ideia.Where(x => x.Data.Year == anoAtual).Count();

            //calculo de quanto em porcentagem aumentou a quantidade de ideias implantadas desse ano comparado com o ano anterior
            var totalIdeiasImplantadasAnoAnterior = _context.Ideia.Where(x => x.Status == "Aplicada" && x.Data.Year == anoAtual - 1).Count();
            var totalIdeiasImplantadasAnoAtual = _context.Ideia.Where(x => x.Status == "Aplicada" && (x.Data.Year == anoAtual || (x.DataImplantacao.HasValue && x.DataImplantacao.Value.Year == anoAtual))).Count();
            ViewBag.PorcentagemIdeiasAno = Math.Round((decimal)(totalIdeiasAnoAtual - totalIdeiasAnoAnterior) / totalIdeiasAnoAnterior * 100, 2);
            ViewBag.PorcentagemIdeiasImplantadasAno = Math.Round((decimal)(totalIdeiasImplantadasAnoAtual - totalIdeiasImplantadasAnoAnterior) / totalIdeiasImplantadasAnoAnterior * 100, 2);
            ViewBag.TotalIdeiasAno = totalIdeiasAnoAtual;
            ViewBag.TotalIdeiasImplantadasAno = totalIdeiasImplantadasAnoAtual;
            return View();
        }

        public PartialViewResult BuscarIdeias(int? idfuncionario)
        {

            if (idfuncionario != null)
            {
                IEnumerable<Ideia> model = _context.Ideia
                .Where(x => x.EquipeIdeia.Any(e => e.IDFuncionario == idfuncionario))
                .OrderByDescending(x => x.Data)
                .Select(i => new Ideia
                {
                    Data = i.Data,
                    Descricao = i.Descricao,
                    IDIdeia = i.IDIdeia,
                    Status = i.Status,
                    NomesEquipe = i.EquipeIdeia.Select(e => e.Funcionario.Nome)
                });
                return PartialView("_GridViewIdeias", model);
            }
            else
            {
                IEnumerable<Ideia> model = (from i in _context.Ideia
                                               select new Ideia { Data = i.Data, Descricao = i.Descricao, IDIdeia = i.IDIdeia, Status = i.Status, NomesEquipe = i.EquipeIdeia.Select(x => x.Funcionario.Nome.ToLower()) })
                                              .OrderByDescending(x => x.Data);
                return PartialView("_GridViewIdeias", model);
            }
        }

        public PartialViewResult BuscarIdeiasLider(int idlider)
        {
            IEnumerable<Ideia> model = _context.Ideia
             .Where(x => x.EquipeIdeia.Any(e => e.Funcionario.IDLider == idlider))
             .OrderByDescending(x => x.Data)
             .ToList();
            return PartialView("_GridViewIdeias", model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var ideia = await _context.Ideia.FindAsync(id);
            return View(ideia);
        }

        [HttpGet]
        [Authorize(Roles = "IdeiaAdmin, Admin")]
        public IActionResult Edit(int id)
        {
            
            var ideia = _context.Ideia.Find(id);
            if (ideia == null)
            {
                return NotFound();
            }
            return View(ideia);
        }

        [HttpPost]
        [Authorize(Roles = "IdeiaAdmin, Admin")]
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
            ViewData["Funcionarios"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).Select(x => new { x.IDFuncionario, x.Nome }), "IDFuncionario", "Nome");
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
                    if (files != null && files.Count > 0)
                    {
                        foreach (var file in files)
                        {
                            if (file.Length > 0)
                            {
                                using (var memoryStream = new MemoryStream())
                                {
                                    file.CopyTo(memoryStream);
                                    byte[] fileBytes = memoryStream.ToArray();

                                    string tipoMime = file.ContentType;
                                    string fileName = file.FileName;

                                    IdeiaAnexo ideiaAnexo = new(fileName, fileBytes, tipoMime, ideia.IDIdeia);
                                    _context.Add(ideiaAnexo);
                                    _context.SaveChanges();
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
                    ViewData["Funcionarios"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).Select(x => new { x.IDFuncionario, x.Nome }), "IDFuncionario", "Nome");
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
        [Authorize(Roles = "IdeiaAdmin, Admin")]
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

        public List<string> GetFuncionariosNomes()
        {
            List<string> nomes = _context.Funcionario
                .Where(x => x.Ativo)
                .Select(x => x.Nome)
                .ToList();
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