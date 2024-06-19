using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schwarz.Data;
using Schwarz.Enums;
using Schwarz.Models;

namespace Schwarz.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PareSegurancaController : ControllerBase
    {
        private readonly SchwarzContext _context;
        public PareSegurancaController(SchwarzContext schwarzContext)
        {
            _context = schwarzContext;
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> Delete(int id)
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
                _context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("/Foto/{id}")]
        public IActionResult DeleteFoto(int id)
        {
            var foto = _context.PareSegurancaFoto.Find(id);
            if (foto != null)
            {
                _context.PareSegurancaFoto.Remove(foto);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        [HttpPost("/Foto")]
        public IActionResult AdicionarFoto(IFormFileCollection fotos, int idPareSeguranca)
        {

            foreach (var foto in fotos)
            {
                using (var memoryStream = new MemoryStream())
                {
                    foto.CopyTo(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();

                    string tipoMime = foto.ContentType;
                    string fileName = foto.FileName;

                    PareSegurancaFoto pareSegurancaFoto = new(idPareSeguranca, fileName, fileBytes, tipoMime);
                    _context.PareSegurancaFoto.Add(pareSegurancaFoto);
                    _context.SaveChanges();
                }
            }
            return Ok();
        }

        [HttpPut("/AprovacaoLider")]
        public async Task<IActionResult> AprovacaoLider(int idPareSeguranca, EAprovacaoPare aprovacaoPare, string? observacoes = null)
        {
            var pareSeguranca = await _context.PareSeguranca.FindAsync(idPareSeguranca);
            if(pareSeguranca == null)
            {
                return NotFound();
            }
            pareSeguranca.AprovacaoLider = aprovacaoPare;
            pareSeguranca.ObservacoesLider = observacoes;
            _context.Update(pareSeguranca);
            _context.SaveChanges();

            return Ok();
        }
        
        [HttpPut("/AprovacaoSeguranca")]
        public async Task<IActionResult> AprovacaoSeguranca(int idPareSeguranca, EAprovacaoPare aprovacaoPare, string? observacoes = null)
        {
            var pareSeguranca = await _context.PareSeguranca.FindAsync(idPareSeguranca);
            if(pareSeguranca == null)
            {
                return NotFound();
            }
            pareSeguranca.AprovacaoSeguranca = aprovacaoPare;
            pareSeguranca.ObservacoesSeguranca = observacoes;
            _context.Update(pareSeguranca);
            _context.SaveChanges();

            return Ok();
        }
       
    }
}
