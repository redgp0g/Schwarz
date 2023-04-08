﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
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

		public PartialViewResult BuscarIdeias()
		{

			IEnumerable<Ideia> model = _ideiaRepository.GetIdeias().OrderByDescending(x => x.Data);
			return PartialView("_GridViewIdeias", model);

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

        [Authorize(Roles = "IdeiaAdmin")]
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
        public IActionResult Create()
        {
            Ideia ideia = new(_context);
            return View(ideia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ideia ideia)
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
                    foreach(var equipe in ideia.EquipeIdeia)
                    {
                        _context.EquipeIdeia.Remove(equipe);
                    }
					_context.Ideia.Remove(ideia);
				}

				await _context.SaveChangesAsync();
				transaction.Commit();
				return RedirectToAction(nameof(Index));
			}
            catch(Exception ex)
            {
				transaction.Rollback();
				TempData["MensagemErro"] = "Houve um erro ao deletar, detalhes do erro" + ex.Message;
                return RedirectToAction(nameof(Index));
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