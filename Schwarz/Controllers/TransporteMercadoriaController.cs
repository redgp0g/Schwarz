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
            try
            {
                transporteMercadoria.Data = DateTime.Now;
                string uploadsDirectory = Path.Combine("\\teste", "fotosRTM");
                if (!Directory.Exists(uploadsDirectory))
                {
                    Directory.CreateDirectory(uploadsDirectory);
                }
                string nomeUnicoArquivo = Guid.NewGuid().ToString() + "_" + transporteMercadoria.fileFotoLacre.FileName;
                string filePath = Path.Combine(uploadsDirectory, nomeUnicoArquivo);

                // Save the file to the file system
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    transporteMercadoria.fileFotoLacre.CopyTo(fileStream);
                }

                transporteMercadoria.FotoLacre = filePath;

                nomeUnicoArquivo = Guid.NewGuid().ToString() + "_" + transporteMercadoria.fileFotoLacre.FileName;
                filePath = Path.Combine(uploadsDirectory, nomeUnicoArquivo);

                // Save the file to the file system
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    transporteMercadoria.fileFotoPlaca.CopyTo(fileStream);
                }

                transporteMercadoria.FotoPlaca = filePath;

                List<string> caminhosFotosAntes = new List<string>();
                for (var i = 0; i < 3; i++)
                {
                    nomeUnicoArquivo = Guid.NewGuid().ToString() + "_" + transporteMercadoria.filesFotosAntes[i].FileName;
                    filePath = Path.Combine(uploadsDirectory, nomeUnicoArquivo);

                    // Save the file to the file system
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        transporteMercadoria.filesFotosAntes[i].CopyTo(fileStream);
                    }
                    caminhosFotosAntes.Add(filePath);
                }
                transporteMercadoria.FotoAntesCarregamento1 = caminhosFotosAntes[0];
                transporteMercadoria.FotoAntesCarregamento2 = caminhosFotosAntes[1];
                transporteMercadoria.FotoAntesCarregamento3 = caminhosFotosAntes[2];


                List<string> caminhosFotosDepois = new List<string>();
                for (var i = 0; i < 3; i++)
                {
                    nomeUnicoArquivo = Guid.NewGuid().ToString() + "_" + transporteMercadoria.filesFotosDepois[i].FileName;
                    filePath = Path.Combine(uploadsDirectory, nomeUnicoArquivo);

                    // Save the file to the file system
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        transporteMercadoria.filesFotosDepois[i].CopyTo(fileStream);
                    }
                    caminhosFotosDepois.Add(filePath);
                }
                transporteMercadoria.FotoDepoisCarregamento1 = caminhosFotosDepois[0];
                transporteMercadoria.FotoDepoisCarregamento2 = caminhosFotosDepois[1];
                transporteMercadoria.FotoDepoisCarregamento3 = caminhosFotosDepois[2];
                transporteMercadoria.IDFuncionario = _userManager.Users.First(x => x.Id == _userManager.GetUserId(User)).Funcionario.IDFuncionario;
                _context.Add(transporteMercadoria);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
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
