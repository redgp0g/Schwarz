using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schwarz.Data;
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

        [HttpDelete("{id}")]
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


        [HttpPut("AprovacaoLider")]
        public async Task<IActionResult> AprovacaoLider([FromForm] int id, [FromForm] string? observacoes = null)
        {
            var pareQualidade = await _context.PareQualidade.FindAsync(id);
            if (pareQualidade == null)
            {
                return NotFound();
            }
            pareQualidade.Status = "Aprovado pelo Lider";
            pareQualidade.ObservacoesLider = observacoes;
            _context.PareQualidade.Update(pareQualidade);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("ReprovacaoLider")]
        public async Task<IActionResult> ReprovacaoLider([FromForm] int id, [FromForm] string? observacoes = null)
        {
            var pareQualidade = await _context.PareQualidade.FindAsync(id);
            if (pareQualidade == null)
            {
                return NotFound();
            }
            pareQualidade.Status = "Reprovado pelo Lider";
            pareQualidade.ObservacoesLider = observacoes;
            _context.PareQualidade.Update(pareQualidade);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("AprovacaoQualidade")]
        public async Task<IActionResult> AprovacaoQualidade([FromForm] int id, [FromForm] string? observacoes = null, [FromForm] int? pontuacao = null)
        {
            var pareQualidade = await _context.PareQualidade.FindAsync(id);
            if (pareQualidade == null)
            {
                return NotFound();
            }
            pareQualidade.Status = "Aprovado pela Qualidade";
            pareQualidade.ObservacoesQualidade = observacoes;
            pareQualidade.Pontuacao = pontuacao;
            _context.PareQualidade.Update(pareQualidade);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("ReprovacaoQualidade")]
        public async Task<IActionResult> ReprovacaoQualidade([FromForm] int id, [FromForm] string? observacoes = null, [FromForm] int? pontuacao = null)
        {
            var pareQualidade = await _context.PareQualidade.FindAsync(id);
            if (pareQualidade == null)
            {
                return NotFound();
            }
            pareQualidade.Status = "Reprovado pela Qualidade";
            pareQualidade.ObservacoesQualidade = observacoes;
            pareQualidade.Pontuacao = pontuacao;
            _context.PareQualidade.Update(pareQualidade);
            _context.SaveChanges();

            return Ok();
        }


    }
}
