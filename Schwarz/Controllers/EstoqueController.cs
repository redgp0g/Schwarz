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
    public class EstoqueController : Controller
    {
        private readonly SchwarzContext _context;

        public EstoqueController(SchwarzContext context)
        {
            _context = context;
        }

        // GET: Estoque
        public async Task<IActionResult> Index()
        {
            var schwarzContext = _context.Estoque.Include(e => e.SchwarzUser);
            return View(await schwarzContext.ToListAsync());
        }

        // GET: Estoque/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estoque == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoque
                .Include(e => e.SchwarzUser)
                .FirstOrDefaultAsync(m => m.IDEstoque == id);
            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        // GET: Estoque/Create
        public IActionResult Create()
        {
            ViewData["IdAspNetUser"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Estoque/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDEstoque,IdAspNetUser,Setor,Urgencia,Data,Peca,Quantidade,Entregue")] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAspNetUser"] = new SelectList(_context.Users, "Id", "Id", estoque.IdAspNetUser);
            return View(estoque);
        }

        // GET: Estoque/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estoque == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoque.FindAsync(id);
            if (estoque == null)
            {
                return NotFound();
            }
            ViewData["IdAspNetUser"] = new SelectList(_context.Users, "Id", "Id", estoque.IdAspNetUser);
            return View(estoque);
        }

        // POST: Estoque/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDEstoque,IdAspNetUser,Setor,Urgencia,Data,Peca,Quantidade,Entregue")] Estoque estoque)
        {
            if (id != estoque.IDEstoque)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estoque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstoqueExists(estoque.IDEstoque))
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
            ViewData["IdAspNetUser"] = new SelectList(_context.Users, "Id", "Id", estoque.IdAspNetUser);
            return View(estoque);
        }

        // GET: Estoque/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estoque == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoque
                .Include(e => e.SchwarzUser)
                .FirstOrDefaultAsync(m => m.IDEstoque == id);
            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        // POST: Estoque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estoque == null)
            {
                return Problem("Entity set 'SchwarzContext.Estoque'  is null.");
            }
            var estoque = await _context.Estoque.FindAsync(id);
            if (estoque != null)
            {
                _context.Estoque.Remove(estoque);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstoqueExists(int id)
        {
          return (_context.Estoque?.Any(e => e.IDEstoque == id)).GetValueOrDefault();
        }
    }
}
