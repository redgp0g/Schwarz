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
            var schwarzContext = _context.LicaoAprendida.Include(x => x.LicaoAprendidaArquivos);
            return View(await schwarzContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licaoAprendida = await _context.LicaoAprendida
                .FirstOrDefaultAsync(m => m.IDLicaoAprendida == id);
            if (licaoAprendida == null)
            {
                return NotFound();
            }

            return View(licaoAprendida);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LicaoAprendida licaoAprendida, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    licaoAprendida.Data = DateTime.Now;
                    using var transaction = _context.Database.BeginTransaction();

                    _context.Add(licaoAprendida);
                    await _context.SaveChangesAsync();

                    if (files != null && files.Count > 0)
                    {
                        foreach (var file in files)
                        {
                            if (file.Length > 0)
                            {
                                using (var memoryStream = new MemoryStream())
                                {
                                    file.CopyTo(memoryStream);
                                    byte[] fileBytes = memoryStream.ToArray();

                                    string tipoMime = file.ContentType;
                                    string fileName = file.FileName;

                                    Arquivo arquivo = new(fileName, fileBytes, tipoMime, DateTime.Now);
                                    _context.Add(arquivo);
                                    _context.SaveChanges();
                                    LicaoAprendidaArquivo licaoAprendidaArquivo = new(licaoAprendida.IDLicaoAprendida, arquivo.IDArquivo);
                                    _context.Add(licaoAprendidaArquivo);
                                    _context.SaveChanges();
                                }
                            }
                        }
                    }
                    transaction.Commit();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["MensagemErro"] = "Houve um erro, por favor tente novamente, detalhe do erro:" + ex.Message;
                    return RedirectToAction("Create");
                }
            }
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
            return View(licaoAprendida);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licaoAprendida = await _context.LicaoAprendida
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
