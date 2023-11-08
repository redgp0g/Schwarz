using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schwarz.Data;
using Schwarz.Models;

namespace Schwarz.Controllers
{
    public class PlanoControleController : Controller
    {
        private readonly SchwarzContext _context;

        public PlanoControleController(SchwarzContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var planoControles = _context.PlanoControle.Include(p => p.FuncionarioAprovador).Include(p => p.FuncionarioElaborador);
            return View(await planoControles.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PlanoControle == null)
            {
                return NotFound();
            }

            var planoControle = await _context.PlanoControle
                .Include(p => p.FuncionarioAprovador)
                .Include(p => p.FuncionarioElaborador)
                .FirstOrDefaultAsync(m => m.IDPlanoControle == id);
            if (planoControle == null)
            {
                return NotFound();
            }

            return View(planoControle);
        }

        public IActionResult Create()
        {
            ViewData["Funcionarios"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).OrderBy(x => x.Nome), "IDFuncionario", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlanoControle planoControle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planoControle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
			ViewData["Funcionarios"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).OrderBy(x => x.Nome), "IDFuncionario", "Nome");
			return View(planoControle);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PlanoControle == null)
            {
                return NotFound();
            }

            var planoControle = await _context.PlanoControle.FindAsync(id);
            if (planoControle == null)
            {
                return NotFound();
            }
			ViewData["Funcionarios"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).OrderBy(x => x.Nome), "IDFuncionario", "Nome");
			return View(planoControle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PlanoControle planoControle)
        {
            if (id != planoControle.IDPlanoControle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planoControle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanoControleExists(planoControle.IDPlanoControle))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
			ViewData["Funcionarios"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).OrderBy(x => x.Nome), "IDFuncionario", "Nome");
			return View(planoControle);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PlanoControle == null)
            {
                return NotFound();
            }

            var planoControle = await _context.PlanoControle
                .Include(p => p.FuncionarioAprovador)
                .Include(p => p.FuncionarioElaborador)
                .FirstOrDefaultAsync(m => m.IDPlanoControle == id);
            if (planoControle == null)
            {
                return NotFound();
            }

            return View(planoControle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PlanoControle == null)
            {
                return Problem("Entity set 'SchwarzContext.PlanoControle'  is null.");
            }
            var planoControle = await _context.PlanoControle.FindAsync(id);
            if (planoControle != null)
            {
                _context.PlanoControle.Remove(planoControle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanoControleExists(int id)
        {
          return (_context.PlanoControle?.Any(e => e.IDPlanoControle == id)).GetValueOrDefault();
        }

        [HttpPost]
        public IActionResult CreateCota(Cota cota)
        {
            if (ModelState.IsValid)
            {
				_context.Add(cota);
				_context.SaveChanges();
                return Ok();
			}
            else
            {
                return NotFound();
            }
            
        }
    }
}
