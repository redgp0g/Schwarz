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

        // GET: PlanoControle
        public async Task<IActionResult> Index()
        {
            var schwarzContext = _context.PlanoControle.Include(p => p.SchwarzUserAprovador).Include(p => p.SchwarzUserElaborador);
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
                .Include(p => p.SchwarzUserAprovador)
                .Include(p => p.SchwarzUserElaborador)
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
            ViewData["IDSchwarzUserAprovador"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome");
            ViewData["IDSchwarzUserElaborador"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome");
            return View();
        }

        // POST: PlanoControle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDPlanoControle,Revisao,DataOrigem,DataAtualizacao,Status,Produto,Cliente,Processo,CodigoInterno,CodigoCliente,NFluxo,Observacoes,IDSchwarzUserElaborador,IDSchwarzUserAprovador")] PlanoControle planoControle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planoControle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDSchwarzUserAprovador"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", planoControle.IDSchwarzUserAprovador);
            ViewData["IDSchwarzUserElaborador"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", planoControle.IDSchwarzUserElaborador);
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
            ViewData["IDSchwarzUserAprovador"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", planoControle.IDSchwarzUserAprovador);
            ViewData["IDSchwarzUserElaborador"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", planoControle.IDSchwarzUserElaborador);
            return View(planoControle);
        }

        // POST: PlanoControle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDPlanoControle,Revisao,DataOrigem,DataAtualizacao,Status,Produto,Cliente,Processo,CodigoInterno,CodigoCliente,NFluxo,Observacoes,IDSchwarzUserElaborador,IDSchwarzUserAprovador")] PlanoControle planoControle)
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
            ViewData["IDSchwarzUserAprovador"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", planoControle.IDSchwarzUserAprovador);
            ViewData["IDSchwarzUserElaborador"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", planoControle.IDSchwarzUserElaborador);
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
                .Include(p => p.SchwarzUserAprovador)
                .Include(p => p.SchwarzUserElaborador)
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
