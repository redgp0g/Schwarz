﻿using System;
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

        // GET: PlanoControle
        public async Task<IActionResult> Index(int? idplano)
        {
            var schwarzContext = _context.PlanoControle.Include(p => p.FuncionarioAprovador).Include(p => p.FuncionarioElaborador);
            return View(await schwarzContext.ToListAsync());
        }

        // GET: PlanoControle/Details/5
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

        // GET: PlanoControle/Create
        public IActionResult Create()
        {
            ViewData["Funcionarios"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).OrderBy(x => x.Nome), "IDFuncionario", "Nome");
            return View();
        }

        // POST: PlanoControle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlanoControle planoControle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planoControle);
                await _context.SaveChangesAsync();
                foreach (var participante in planoControle.EquipeIds)
                {
                    PlanoControleEquipe equipePlanocontrole = new(participante, planoControle.IDPlanoControle);
                    _context.Add(equipePlanocontrole);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
			ViewData["Funcionarios"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).OrderBy(x => x.Nome), "IDFuncionario", "Nome");
			return View(planoControle);
        }

        // GET: PlanoControle/Edit/5
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

        // POST: PlanoControle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: PlanoControle/Delete/5
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

        // POST: PlanoControle/Delete/5
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
    }
}
