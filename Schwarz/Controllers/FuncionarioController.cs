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
    public class FuncionarioController : Controller
    {
        private readonly SchwarzContext _context;

        public FuncionarioController(SchwarzContext context)
        {
            _context = context;
        }

        // GET: Funcionario
        public async Task<IActionResult> Index()
        {
            var schwarzContext = _context.Funcionario.Include(f => f.FuncionarioLider);
            return View(await schwarzContext.ToListAsync());
        }

        // GET: Funcionario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Funcionario == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .Include(f => f.FuncionarioLider)
                .FirstOrDefaultAsync(m => m.IDFuncionario == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionario/Create
        public IActionResult Create()
        {
            ViewData["IDLider"] = new SelectList(_context.Funcionario, "IDFuncionario", "IDFuncionario");
            return View();
        }

        // POST: Funcionario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDFuncionario,Matricula,Nome,Setor,CentroCusto,DataNascimento,Ativo,Turno,Email,IDLider,Cargo,Ramal,Foto,Telefone,DataAdmissao")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDLider"] = new SelectList(_context.Funcionario, "IDFuncionario", "IDFuncionario", funcionario.IDLider);
            return View(funcionario);
        }

        // GET: Funcionario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Funcionario == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            ViewData["IDLider"] = new SelectList(_context.Funcionario, "IDFuncionario", "IDFuncionario", funcionario.IDLider);
            return View(funcionario);
        }

        // POST: Funcionario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDFuncionario,Matricula,Nome,Setor,CentroCusto,DataNascimento,Ativo,Turno,Email,IDLider,Cargo,Ramal,Foto,Telefone,DataAdmissao")] Funcionario funcionario)
        {
            if (id != funcionario.IDFuncionario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.IDFuncionario))
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
            ViewData["IDLider"] = new SelectList(_context.Funcionario, "IDFuncionario", "IDFuncionario", funcionario.IDLider);
            return View(funcionario);
        }

        // GET: Funcionario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Funcionario == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .Include(f => f.FuncionarioLider)
                .FirstOrDefaultAsync(m => m.IDFuncionario == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Funcionario == null)
            {
                return Problem("Entity set 'SchwarzContext.Funcionario'  is null.");
            }
            var funcionario = await _context.Funcionario.FindAsync(id);
            if (funcionario != null)
            {
                _context.Funcionario.Remove(funcionario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
          return (_context.Funcionario?.Any(e => e.IDFuncionario == id)).GetValueOrDefault();
        }
    }
}
