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
    public class CadastroPareController : Controller
    {
        private readonly SchwarzContext _context;

        public CadastroPareController(SchwarzContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var schwarzContext = _context.CadastroPare.Include(c => c.Falha).Include(c => c.FuncionarioFacilitador).Include(c => c.Funcionario);
            return View(await schwarzContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroPare = await _context.CadastroPare
                .Include(c => c.Falha)
                .Include(c => c.FuncionarioFacilitador)
                .Include(c => c.Funcionario)
                .FirstOrDefaultAsync(m => m.IDCadastroPare == id);
            if (cadastroPare == null)
            {
                return NotFound();
            }

            return View(cadastroPare);
        }

        public IActionResult Create()
        {
            ViewData["IDFalha"] = new SelectList(_context.Falha, "IDFalha", "IDFalha");
            ViewData["IDFuncionarioFacilitador"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome");
            ViewData["IDFuncionario"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome");
            return View();
        }

        // POST: CadastroPare/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CadastroPare cadastroPare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroPare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDFalha"] = new SelectList(_context.Falha, "IDFalha", "IDFalha", cadastroPare.IDFalha);
            ViewData["IDFuncionarioFacilitador"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome", cadastroPare.IDFuncionarioFacilitador);
            ViewData["IDFuncionario"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome", cadastroPare.IDFuncionario);
            return View(cadastroPare);
        }

        // GET: CadastroPare/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroPare = await _context.CadastroPare.FindAsync(id);
            if (cadastroPare == null)
            {
                return NotFound();
            }
            ViewData["IDFalha"] = new SelectList(_context.Falha, "IDFalha", "IDFalha", cadastroPare.IDFalha);
            ViewData["IDFuncionarioFacilitador"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome", cadastroPare.IDFuncionarioFacilitador);
            ViewData["IDFuncionario"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome", cadastroPare.IDFuncionario);
            return View(cadastroPare);
        }

        // POST: CadastroPare/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CadastroPare cadastroPare)
        {
            if (id != cadastroPare.IDCadastroPare)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroPare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;

                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDFalha"] = new SelectList(_context.Falha, "IDFalha", "IDFalha", cadastroPare.IDFalha);
            ViewData["IDFuncionarioFacilitador"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome", cadastroPare.IDFuncionarioFacilitador);
            ViewData["IDFuncionario"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome", cadastroPare.IDFuncionario);
            return View(cadastroPare);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroPare = await _context.CadastroPare.FindAsync(id);
            if (cadastroPare != null)
            {
                _context.CadastroPare.Remove(cadastroPare);
                return Ok();
            }

            return NotFound();
        }

    }
}
