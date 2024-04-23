using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Schwarz.Models;

namespace Schwarz.Controllers
{
    public class TransporteMercadoriaController : Controller
    {
        private readonly SchwarzContext _context;
        private readonly UserManager<SchwarzUser> _userManager;
        public TransporteMercadoriaController(SchwarzContext context, UserManager<SchwarzUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var schwarzContext = _context.TransporteMercadoria.Include(t => t.Cliente).Include(t => t.Funcionario);
            return View(await schwarzContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transporteMercadoria = await _context.TransporteMercadoria
                .Include(t => t.Cliente)
                .Include(t => t.Funcionario)
                .FirstOrDefaultAsync(m => m.IDTransporteMercadoria == id);
            if (transporteMercadoria == null)
            {
                return NotFound();
            }

            return View(transporteMercadoria);
        }

        public IActionResult Create()
        {
            ViewData["Clientes"] = new SelectList(_context.Cliente, "IDCliente", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TransporteMercadoria transporteMercadoria)
        {

            transporteMercadoria.IDFuncionario = _userManager.Users.First(x => x.Id == _userManager.GetUserId(User)).Funcionario.IDFuncionario;
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                _context.Add(transporteMercadoria);
                _context.SaveChanges();
                if (transporteMercadoria.filesFotosDepois != null)
                {
                    for (int i = 0; i < transporteMercadoria.filesFotosDepois.Count; i++)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            transporteMercadoria.filesFotosDepois[i].CopyTo(memoryStream);
                            byte[] fileBytes = memoryStream.ToArray();

                            string fileName = "Foto Depois do Carregamento " + (i + 1);
                            string fileMime = transporteMercadoria.filesFotosDepois[i].ContentType;

                            TransporteMercadoriaFoto transporteMercadoriaFoto = new(transporteMercadoria.IDTransporteMercadoria, fileName, fileBytes, fileMime);
                            _context.Add(transporteMercadoriaFoto);
                            _context.SaveChanges();
                        }
                    }
                }

                if (transporteMercadoria.filesFotosAntes!= null)
                {
                    for (int i = 0; i < transporteMercadoria.filesFotosAntes.Count; i++)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            transporteMercadoria.filesFotosAntes[i].CopyTo(memoryStream);
                            byte[] fileBytes = memoryStream.ToArray();

                            string fileName = "Foto Antes do Carregamento " + (i + 1);
                            string fileMime = transporteMercadoria.filesFotosAntes[i].ContentType;

                            TransporteMercadoriaFoto transporteMercadoriaFoto = new(transporteMercadoria.IDTransporteMercadoria, fileName, fileBytes, fileMime);
                            _context.Add(transporteMercadoriaFoto);
                            _context.SaveChanges();
                        }
                    }
                }

                using (var memoryStream = new MemoryStream())
                {
                    transporteMercadoria.fileFotoLacre.CopyTo(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();

                    string fileName = "Foto do Lacre";
                    string fileMime = transporteMercadoria.fileFotoLacre.ContentType;

                    TransporteMercadoriaFoto transporteMercadoriaFoto = new(transporteMercadoria.IDTransporteMercadoria, fileName, fileBytes, fileMime);
                    _context.Add(transporteMercadoriaFoto);
                    _context.SaveChanges();
                }

                using (var memoryStream = new MemoryStream())
                {
                    transporteMercadoria.fileFotoPlaca.CopyTo(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();

                    string fileName = "Foto do Placa";
                    string fileMime = transporteMercadoria.fileFotoPlaca.ContentType;

                    TransporteMercadoriaFoto transporteMercadoriaFoto = new(transporteMercadoria.IDTransporteMercadoria, fileName, fileBytes, fileMime);
                    _context.Add(transporteMercadoriaFoto);
                    _context.SaveChanges();
                }

                transaction.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                TempData["MensagemErro"] = "Houve um erro, por favor tente novamente, detalhe do erro:" + ex.Message;
                return RedirectToAction("Create");
            }
        }

        // GET: TransporteMercadoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transporteMercadoria = await _context.TransporteMercadoria.FindAsync(id);
            if (transporteMercadoria == null)
            {
                return NotFound();
            }
            ViewData["IDCliente"] = new SelectList(_context.Cliente, "IDCliente", "Nome", transporteMercadoria.IDCliente);
            ViewData["IDFuncionario"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome", transporteMercadoria.IDFuncionario);
            return View(transporteMercadoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TransporteMercadoria transporteMercadoria)
        {
            if (id != transporteMercadoria.IDTransporteMercadoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transporteMercadoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransporteMercadoriaExists(transporteMercadoria.IDTransporteMercadoria))
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
            ViewData["IDCliente"] = new SelectList(_context.Cliente, "IDCliente", "Nome", transporteMercadoria.IDCliente);
            ViewData["IDFuncionario"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome", transporteMercadoria.IDFuncionario);
            return View(transporteMercadoria);
        }

        // GET: TransporteMercadoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transporteMercadoria = await _context.TransporteMercadoria
                .Include(t => t.Cliente)
                .Include(t => t.Funcionario)
                .FirstOrDefaultAsync(m => m.IDTransporteMercadoria == id);
            if (transporteMercadoria == null)
            {
                return NotFound();
            }

            return View(transporteMercadoria);
        }

        // POST: TransporteMercadoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transporteMercadoria = await _context.TransporteMercadoria.FindAsync(id);
            if (transporteMercadoria != null)
            {
                _context.TransporteMercadoria.Remove(transporteMercadoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransporteMercadoriaExists(int id)
        {
            return _context.TransporteMercadoria.Any(e => e.IDTransporteMercadoria == id);
        }
    }
}
