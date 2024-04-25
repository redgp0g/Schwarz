using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schwarz.Data;
using Schwarz.Models;

namespace Schwarz.Controllers
{
    [Authorize(Roles = "LicaoAprendida, Admin")]
    public class LicaoAprendidaController : Controller
    {
        private readonly SchwarzContext _context;

        public LicaoAprendidaController(SchwarzContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var schwarzContext = _context.LicaoAprendida.Include(x => x.LicaoAprendidaAnexos);
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
        public async Task<IActionResult> Create(LicaoAprendida licaoAprendida)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    licaoAprendida.Data = DateTime.Now;
                    using var transaction = _context.Database.BeginTransaction();

                    _context.Add(licaoAprendida);
                    await _context.SaveChangesAsync();

                    if (licaoAprendida.Arquivos != null && licaoAprendida.Arquivos.Count > 0)
                    {
                        foreach (var file in licaoAprendida.Arquivos)
                        {
                            if (file.Length > 0)
                            {
                                using (var memoryStream = new MemoryStream())
                                {
                                    file.CopyTo(memoryStream);
                                    byte[] fileBytes = memoryStream.ToArray();

                                    string tipoMime = file.ContentType;
                                    string fileName = file.FileName;

                                    LicaoAprendidaAnexo anexo = new(licaoAprendida.IDLicaoAprendida, fileName, fileBytes, tipoMime);
                                    _context.Add(anexo);
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

        public async Task<IActionResult> Delete(int id)
        {
            var licaoAprendida = await _context.LicaoAprendida.FindAsync(id);
            if (licaoAprendida == null)
            {
                return NotFound();
            }
            if (licaoAprendida.LicaoAprendidaAnexos != null)
            {
                foreach (var licaoAprendidaArquivo in licaoAprendida.LicaoAprendidaAnexos)
                {
                    _context.Remove(licaoAprendidaArquivo);
                }
            }

            _context.LicaoAprendida.Remove(licaoAprendida);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool LicaoAprendidaExists(int id)
        {
            return _context.LicaoAprendida.Any(e => e.IDLicaoAprendida == id);
        }

        [HttpPost]
        public IActionResult AdicionarAnexo(IFormFileCollection files, int idLicaoAprendida)
        {
            try
            {
                foreach (var file in files)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);
                        byte[] fileBytes = memoryStream.ToArray();

                        string tipoMime = file.ContentType;
                        string fileName = file.FileName;

                        LicaoAprendidaAnexo licaoAprendidaAnexo= new(idLicaoAprendida, fileName, fileBytes, tipoMime);
                        _context.Add(licaoAprendidaAnexo);
                        _context.SaveChanges();
                    }
                }
                return Ok();
            }

            catch (Exception ex)
            {
                return Json(new
                {
                    error = "Ocorreu um erro ao adicionar o anexo: " + ex.Message
                });
            }
        }

        [HttpPost]
        public IActionResult RemoverAnexo(int id)
        {
            var anexo = _context.LicaoAprendidaAnexo.Find(id);
            if (anexo != null)
            {
                _context.LicaoAprendidaAnexo.Remove(anexo);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

    }
}
