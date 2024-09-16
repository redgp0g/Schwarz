using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schwarz.Data;
using Schwarz.Models;
using Schwarz.Statics;

namespace Schwarz.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{Roles.PareQualidade}, {Roles.Lider}, {Roles.Admin}")]
    public class PareQualidadeController : ControllerBase
    {
        private readonly SchwarzContext _context;
        public PareQualidadeController(SchwarzContext schwarzContext)
        {
            _context = schwarzContext;
        }

        [Authorize(Roles = $"{Roles.PareQualidade}, {Roles.Admin}")]
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
            pareQualidade.Status = StatusPare.AprovadoLider;
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
            pareQualidade.Status = StatusPare.ReprovadoLider;
            pareQualidade.ObservacoesLider = observacoes;
            _context.PareQualidade.Update(pareQualidade);
            _context.SaveChanges();

            return Ok();
        }

        [Authorize(Roles = $"{Roles.PareQualidade}, {Roles.Admin}")]
        [HttpPut("AprovacaoQualidade")]
        public async Task<IActionResult> AprovacaoQualidade([FromForm] int id, [FromForm] string? observacoes = null, [FromForm] int? pontuacao = null)
        {
            var pareQualidade = await _context.PareQualidade.FindAsync(id);
            if (pareQualidade == null)
            {
                return NotFound();
            }
            pareQualidade.Status = StatusPare.AprovadoQualidade;
            pareQualidade.ObservacoesQualidade = observacoes;
            pareQualidade.Pontuacao = pontuacao;
            _context.PareQualidade.Update(pareQualidade);
            _context.SaveChanges();

            return Ok();
        }

        [Authorize(Roles = $"{Roles.PareQualidade}, {Roles.Admin}")]
        [HttpPut("ReprovacaoQualidade")]
        public async Task<IActionResult> ReprovacaoQualidade([FromForm] int id, [FromForm] string? observacoes = null, [FromForm] int? pontuacao = null)
        {
            var pareQualidade = await _context.PareQualidade.FindAsync(id);
            if (pareQualidade == null)
            {
                return NotFound();
            }
            pareQualidade.Status = StatusPare.ReprovadoQualidade;
            pareQualidade.ObservacoesQualidade = observacoes;
            pareQualidade.Pontuacao = pontuacao;
            _context.PareQualidade.Update(pareQualidade);
            _context.SaveChanges();

            return Ok();
        }


    }
}
