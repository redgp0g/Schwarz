using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        public async Task<IActionResult> Index()
        {
            var schwarzContext = _context.Funcionario.Select(f => new Funcionario
            {
                Matricula = f.Matricula,
                Nome = f.Nome,
                IDFuncionario = f.IDFuncionario,
                Setor = f.Setor,
                Turno = f.Turno,
                Email = f.Email,
                Cargo = f.Cargo,
                Ativo = f.Ativo
            });
            ViewData["Lideres"] = new SelectList(_context.Funcionario.Select(x => new { x.IDFuncionario, x.Nome }), "IDFuncionario", "Nome");
            return View(await schwarzContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Funcionario == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .FirstOrDefaultAsync(m => m.IDFuncionario == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        public IActionResult Create()
        {
            ViewData["IDLider"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDLider"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome", funcionario.IDLider);
            return View(funcionario);
        }

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
            ViewData["IDLider"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome", funcionario.IDLider);
            return View(funcionario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Funcionario funcionario, IFormFile NovaFoto)
        {
            if (ModelState.IsValid)
            {
                if (NovaFoto != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        NovaFoto.CopyTo(memoryStream);
                        byte[] fileBytes = memoryStream.ToArray();
                        funcionario.Foto = fileBytes;
                    }
                }

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
            ViewData["IDLider"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome", funcionario.IDLider);
            return View(funcionario);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Funcionario == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .FirstOrDefaultAsync(m => m.IDFuncionario == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

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


        [HttpGet]
        public IActionResult BuscarDadosFuncionario(int id)
        {
            var funcionario = _context.Funcionario.Find(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            var possuiConta = false;
            var contaFuncionario = _context.Users.Select(x => new { x.Id, x.IDFuncionario }).FirstOrDefault(x => x.IDFuncionario == funcionario.IDFuncionario);
            if (contaFuncionario != null)
            {
                possuiConta = true;
            }
            return Json(new
            {
                IDFuncionario = funcionario.IDFuncionario,
                Matricula = funcionario.Matricula,
                Nome = funcionario.Nome,
                Setor = funcionario.Setor,
                DataNascimento = funcionario.DataNascimento.HasValue
        ? funcionario.DataNascimento.Value.ToString("yyyy-MM-dd")
        : null,
                Ativo = funcionario.Ativo,
                Turno = funcionario.Turno,
                Email = funcionario.Email,
                IDLider = funcionario.IDLider,
                Cargo = funcionario.Cargo,
                Ramal = funcionario.Ramal,
                Foto = funcionario.Foto,
                Telefone = funcionario.Telefone,
                CentroCusto = funcionario.CentroCusto,
                DataAdmissao = funcionario.DataAdmissao.HasValue
        ? funcionario.DataAdmissao.Value.ToString("yyyy-MM-dd")
        : null,
                PossuiConta = possuiConta
            });
        }
    }
}
