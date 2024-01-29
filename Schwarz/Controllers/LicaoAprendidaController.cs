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
    public class LicaoAprendidaController : Controller
    {
        private readonly SchwarzContext _context;

        public LicaoAprendidaController(SchwarzContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var schwarzContext = _context.LicaoAprendida.Include(l => l.Falha);
            return View(await schwarzContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licaoAprendida = await _context.LicaoAprendida
                .Include(l => l.Falha)
                .FirstOrDefaultAsync(m => m.IDLicaoAprendida == id);
            if (licaoAprendida == null)
            {
                return NotFound();
            }

            return View(licaoAprendida);
        }

        public IActionResult Create()
        {
            ViewData["IDFalha"] = new SelectList(_context.Falha.OrderBy(x => x.Descricao), "IDFalha", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LicaoAprendida licaoAprendida)
        {
            if (ModelState.IsValid)
            {
                licaoAprendida.Data = DateTime.Now;
                _context.Add(licaoAprendida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDFalha"] = new SelectList(_context.Falha, "IDFalha", "Descricao");
            return View(licaoAprendida);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licaoAprendida = await _context.LicaoAprendida.FindAsync(id);
            if (licaoAprendida == null)
            {
                return NotFound();
            }
            ViewData["IDFalha"] = new SelectList(_context.Falha, "IDFalha", "IDFalha", licaoAprendida.IDFalha);
            return View(licaoAprendida);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LicaoAprendida licaoAprendida)
        {
            if (id != licaoAprendida.IDLicaoAprendida)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(licaoAprendida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LicaoAprendidaExists(licaoAprendida.IDLicaoAprendida))
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
            ViewData["IDFalha"] = new SelectList(_context.Falha, "IDFalha", "IDFalha", licaoAprendida.IDFalha);
            return View(licaoAprendida);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licaoAprendida = await _context.LicaoAprendida
                .Include(l => l.Falha)
                .FirstOrDefaultAsync(m => m.IDLicaoAprendida == id);
            if (licaoAprendida == null)
            {
                return NotFound();
            }

            return View(licaoAprendida);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var licaoAprendida = await _context.LicaoAprendida.FindAsync(id);
            if (licaoAprendida != null)
            {
                _context.LicaoAprendida.Remove(licaoAprendida);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LicaoAprendidaExists(int id)
        {
            return _context.LicaoAprendida.Any(e => e.IDLicaoAprendida == id);
        }
    }
}
