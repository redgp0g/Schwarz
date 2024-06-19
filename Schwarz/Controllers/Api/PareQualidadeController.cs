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
    public class PareQualidadeController : ControllerBase
    {
        private readonly SchwarzContext _context;
        public PareQualidadeController(SchwarzContext schwarzContext)
        {
            _context = schwarzContext;
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteQualidade(int id)
        {
            var pareQualidade = await _context.PareQualidade.FindAsync(id);
            if (pareQualidade != null)
            {
                _context.PareQualidade.Remove(pareQualidade);
                _context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

       
        
        [HttpPut("/AprovacaoLider")]
        public async Task<IActionResult> AprovarLider(int idPareQualidade, EAprovacaoPare aprovacaoPare, string? acao = null)
        {
            var pareQualidade= await _context.PareQualidade.FindAsync(idPareQualidade);
            if(pareQualidade == null)
            {
                return NotFound();
            }
            pareQualidade.AprovacaoLider = aprovacaoPare;
            pareQualidade.AcaoLider = acao;
            _context.PareQualidade.Update(pareQualidade);
            _context.SaveChanges();

            return Ok();
        }
        
        [HttpPut("/AprovacaoQualidade")]
        public async Task<IActionResult> AprovarQualidade(int idPareQualidade, EAprovacaoPare aprovacaoPare, string? observacoes = null)
        {
            var pareQualidade= await _context.PareQualidade.FindAsync(idPareQualidade);
            if(pareQualidade == null)
            {
                return NotFound();
            }
            pareQualidade.AprovacaoQualidade = aprovacaoPare;
            pareQualidade.ObservacoesQualidade = observacoes;
            _context.PareQualidade.Update(pareQualidade);
            _context.SaveChanges();

            return Ok();
        }
        
       
    }
}
