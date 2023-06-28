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
    public class CotaController : Controller
    {
        private readonly SchwarzContext _context;

        public CotaController(SchwarzContext context)
        {
            _context = context;
        }

        // GET: Cota
        public async Task<IActionResult> Index()
        {
            var schwarzContext = _context.Cota.Include(c => c.PlanoControle);
            return View(await schwarzContext.ToListAsync());
        }

        // GET: Cota/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cota == null)
            {
                return NotFound();
            }

            var cota = await _context.Cota
                .Include(c => c.PlanoControle)
                .FirstOrDefaultAsync(m => m.IDCota == id);
            if (cota == null)
            {
                return NotFound();
            }

            return View(cota);
        }

        // GET: Cota/Create
        public IActionResult Create()
        {
            ViewData["IDPlanoControle"] = new SelectList(_context.PlanoControle, "IDPlanoControle", "IDPlanoControle");
            return View();
        }

        // POST: Cota/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDCota,IDPlanoControle,Item,CaracteristicaEspecial,Localizacao,CaracteristicaProduto,CaracteristicaProcesso,Descricao,ToleranciaSuperior,ToleranciaInferior,InstrumentoPrincipal,CodigoIP,FrequenciaMinimaDiaIP,FrequenciaMinimaTurnoIP,FrequenciaMinimaSetUpIP,FrequenciaMinimaParadaIP,FrequenciaMinimaFinalIP,FrequenciaMinimaAjusteIP,FrequenciaMinimaHoraIP,AmostragemIP,MetodoIP,InstrumentoAlternativo,FrequenciaMinimaDiaIA,FrequenciaMinimaTurnoIA,FrequenciaMinimaSetUpIA,FrequenciaMinimaParadaIA,FrequenciaMinimaFinalIA,FrequenciaMinimaAjusteIA,FrequenciaMinimaHoraIA,AmostragemIA,MetodoIA")] Cota cota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDPlanoControle"] = new SelectList(_context.PlanoControle, "IDPlanoControle", "IDPlanoControle", cota.IDPlanoControle);
            return View(cota);
        }

        // GET: Cota/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cota == null)
            {
                return NotFound();
            }

            var cota = await _context.Cota.FindAsync(id);
            if (cota == null)
            {
                return NotFound();
            }
            ViewData["IDPlanoControle"] = new SelectList(_context.PlanoControle, "IDPlanoControle", "IDPlanoControle", cota.IDPlanoControle);
            return View(cota);
        }

        // POST: Cota/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDCota,IDPlanoControle,Item,CaracteristicaEspecial,Localizacao,CaracteristicaProduto,CaracteristicaProcesso,Descricao,ToleranciaSuperior,ToleranciaInferior,InstrumentoPrincipal,CodigoIP,FrequenciaMinimaDiaIP,FrequenciaMinimaTurnoIP,FrequenciaMinimaSetUpIP,FrequenciaMinimaParadaIP,FrequenciaMinimaFinalIP,FrequenciaMinimaAjusteIP,FrequenciaMinimaHoraIP,AmostragemIP,MetodoIP,InstrumentoAlternativo,FrequenciaMinimaDiaIA,FrequenciaMinimaTurnoIA,FrequenciaMinimaSetUpIA,FrequenciaMinimaParadaIA,FrequenciaMinimaFinalIA,FrequenciaMinimaAjusteIA,FrequenciaMinimaHoraIA,AmostragemIA,MetodoIA")] Cota cota)
        {
            if (id != cota.IDCota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CotaExists(cota.IDCota))
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
            ViewData["IDPlanoControle"] = new SelectList(_context.PlanoControle, "IDPlanoControle", "IDPlanoControle", cota.IDPlanoControle);
            return View(cota);
        }

        // GET: Cota/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cota == null)
            {
                return NotFound();
            }

            var cota = await _context.Cota
                .Include(c => c.PlanoControle)
                .FirstOrDefaultAsync(m => m.IDCota == id);
            if (cota == null)
            {
                return NotFound();
            }

            return View(cota);
        }

        // POST: Cota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cota == null)
            {
                return Problem("Entity set 'SchwarzContext.Cota'  is null.");
            }
            var cota = await _context.Cota.FindAsync(id);
            if (cota != null)
            {
                _context.Cota.Remove(cota);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CotaExists(int id)
        {
          return (_context.Cota?.Any(e => e.IDCota == id)).GetValueOrDefault();
        }
    }
}
