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
    public class PareController : Controller
    {
        private readonly SchwarzContext _context;

        public PareController(SchwarzContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexQualidade()
        {
            var model = _context.PareQualidade.Include(c => c.Falha).Include(c => c.Funcionario);
            return View(await model.ToListAsync());
        }

        public async Task<IActionResult> IndexSeguranca()
        {
            var model = _context.PareSeguranca.Include(c => c.Funcionario);
            return View(await model.ToListAsync());
        }

        public async Task<IActionResult> IndexMeioAmbiente()
        {
            var model = _context.PareMeioAmbiente.Include(c => c.Funcionario);
            return View(await model.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["IDFalha"] = new SelectList(_context.Falha, "IDFalha", "Descricao");
            ViewData["Funcionarios"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).Select(x => new { x.IDFuncionario, x.Nome }), "IDFuncionario", "Nome");
            ViewData["Setor"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).Select(x => new { x.Setor }).Distinct(), "Setor", "Setor");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQualidade(PareQualidade pareQualidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pareQualidade);
                await _context.SaveChangesAsync();
                return RedirectToAction("IndexQualidade");
            }
            return RedirectToAction("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSeguranca(PareSeguranca pareSeguranca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pareSeguranca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMeioAmbiente(PareMeioAmbiente pareMeioAmbiente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pareMeioAmbiente);
                await _context.SaveChangesAsync();
                return RedirectToAction("IndexMeioAmbiente");
            }
            return RedirectToAction("Create");
        }

        // GET: CadastroPare/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pareQualidade = await _context.PareQualidade.FindAsync(id);
            if (pareQualidade == null)
            {
                return NotFound();
            }
            ViewData["IDFalha"] = new SelectList(_context.Falha, "IDFalha", "IDFalha", pareQualidade.IDFalha);
            ViewData["IDFuncionario"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome", pareQualidade.IDFuncionario);
            return View(pareQualidade);
        }

        // POST: CadastroPare/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PareQualidade pareQualidade)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pareQualidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;

                }
                return RedirectToAction("IndexQualidade");
            }
            ViewData["IDFalha"] = new SelectList(_context.Falha, "IDFalha", "IDFalha", pareQualidade.IDFalha);
            ViewData["IDFuncionario"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome", pareQualidade.IDFuncionario);
            return View(pareQualidade);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteQualidade(int id)
        {
            var pareQualidade = await _context.PareQualidade.FindAsync(id);
            if (pareQualidade != null)
            {
                _context.PareQualidade.Remove(pareQualidade);
                return Ok();
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSeguranca(int id)
        {
            var pareSeguranca = await _context.PareSeguranca.FindAsync(id);
            if (pareSeguranca != null)
            {
                if (pareSeguranca.PareSegurancaFotos != null)
                {
                    foreach (var foto in pareSeguranca.PareSegurancaFotos)
                    {
                        _context.PareSegurancaFoto.Remove(foto);
                    }
                }
                _context.PareSeguranca.Remove(pareSeguranca);
                return Ok();
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMeioAmbiente(int id)
        {
            var pareMeioAmbiente = await _context.PareMeioAmbiente.FindAsync(id);
            if (pareMeioAmbiente != null)
            {
                _context.PareMeioAmbiente.Remove(pareMeioAmbiente);
                return Ok();
            }

            return NotFound();
        }

    }
}
