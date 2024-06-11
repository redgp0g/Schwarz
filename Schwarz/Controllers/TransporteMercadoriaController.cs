using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Schwarz.Models;

namespace Schwarz.Controllers
{
    [Authorize(Roles = "Admin, TransporteMercadoria")]
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
            IEnumerable<TransporteMercadoria> transporteMercadorias = (from t in _context.TransporteMercadoria
                                                                       select new TransporteMercadoria
                                                                       {
                                                                           IDTransporteMercadoria = t.IDTransporteMercadoria,
                                                                           Data = t.Data,
                                                                           Cliente = new Cliente
                                                                           {
                                                                               Nome = t.Cliente.Nome,
                                                                           },
                                                                           Funcionario = new Funcionario
                                                                           {
                                                                               Nome = t.Funcionario.Nome,
                                                                           },
                                                                           NotaFiscal = t.NotaFiscal,
                                                                           Volume = t.Volume,
                                                                           TipoVolume = t.TipoVolume,
                                                                           Transportadora = t.Transportadora,
                                                                           Placa = t.Placa,
                                                                           Fotos = _context.TransporteMercadoriaFoto
                                                                                   .Where(f => f.IDTransporteMercadoria == t.IDTransporteMercadoria)
                                                                                   .Select(x => new TransporteMercadoriaFoto
                                                                                   {
                                                                                       IDTransporteMercadoriaFoto = x.IDTransporteMercadoriaFoto,
                                                                                       Nome = x.Nome,
                                                                                       TipoMIME = x.TipoMIME

                                                                                   }).ToList()
                                                                       });
            return View(transporteMercadorias);
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

                for (int i = 0; i < transporteMercadoria.filesFotoDepois.Count; i++)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        transporteMercadoria.filesFotoDepois[i].CopyTo(memoryStream);
                        byte[] fileBytes = memoryStream.ToArray();

                        string fileName = "Foto Depois do Carregamento " + (i + 1);
                        string fileMime = transporteMercadoria.filesFotoDepois[i].ContentType;

                        TransporteMercadoriaFoto transporteMercadoriaFoto = new(transporteMercadoria.IDTransporteMercadoria, fileName, fileBytes, fileMime);
                        _context.Add(transporteMercadoriaFoto);
                        _context.SaveChanges();
                    }
                }


                for (int i = 0; i < transporteMercadoria.filesFotoAntes.Count; i++)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        transporteMercadoria.filesFotoAntes[i].CopyTo(memoryStream);
                        byte[] fileBytes = memoryStream.ToArray();

                        string fileName = "Foto Antes do Carregamento " + (i + 1);
                        string fileMime = transporteMercadoria.filesFotoAntes[i].ContentType;

                        TransporteMercadoriaFoto transporteMercadoriaFoto = new(transporteMercadoria.IDTransporteMercadoria, fileName, fileBytes, fileMime);
                        _context.Add(transporteMercadoriaFoto);
                        _context.SaveChanges();
                    }
                }


                for (int i = 0; i < transporteMercadoria.filesFotoNotaFiscal.Count; i++)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        transporteMercadoria.filesFotoNotaFiscal[i].CopyTo(memoryStream);
                        byte[] fileBytes = memoryStream.ToArray();

                        string fileName = "Foto da Nota Fiscal " + (i + 1);
                        string fileMime = transporteMercadoria.filesFotoNotaFiscal[i].ContentType;

                        TransporteMercadoriaFoto transporteMercadoriaFoto = new(transporteMercadoria.IDTransporteMercadoria, fileName, fileBytes, fileMime);
                        _context.Add(transporteMercadoriaFoto);
                        _context.SaveChanges();
                    }
                }


                if (transporteMercadoria.fileFotoLacre != null)
                {
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
                }

                using (var memoryStream = new MemoryStream())
                {
                    transporteMercadoria.fileFotoPlaca.CopyTo(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();

                    string fileName = "Foto da Placa";
                    string fileMime = transporteMercadoria.fileFotoPlaca.ContentType;

                    TransporteMercadoriaFoto transporteMercadoriaFoto = new(transporteMercadoria.IDTransporteMercadoria, fileName, fileBytes, fileMime);
                    _context.Add(transporteMercadoriaFoto);
                    _context.SaveChanges();
                }

                using (var memoryStream = new MemoryStream())
                {
                    transporteMercadoria.fileFotoRomaneio.CopyTo(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();

                    string fileName = "Foto do Romaneio";
                    string fileMime = transporteMercadoria.fileFotoRomaneio.ContentType;

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
