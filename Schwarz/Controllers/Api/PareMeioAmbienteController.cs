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
    [Authorize(Roles = "PareMeioAmbiente, Lider, Admin")]
    public class PareMeioAmbienteController : ControllerBase
    {
        private readonly SchwarzContext _context;
        public PareMeioAmbienteController(SchwarzContext schwarzContext)
        {
            _context = schwarzContext;
        }

        [Authorize(Roles = "PareMeioAmbiente, Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pareMeioAmbiente = await _context.PareMeioAmbiente.FindAsync(id);
            if (pareMeioAmbiente != null)
            {
                _context.PareMeioAmbiente.Remove(pareMeioAmbiente);
                _context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        [Authorize(Roles = "Lider, Admin")]
        [HttpPut("AprovacaoLider")]
        public async Task<IActionResult> AprovacaoLider([FromForm] int id, [FromForm] string? observacoes = null)
        {
            var pareMeioAmbiente = await _context.PareMeioAmbiente.FindAsync(id);
            if (pareMeioAmbiente == null)
            {
                return NotFound();
            }
            pareMeioAmbiente.Status = "Aprovado pelo Líder";
            pareMeioAmbiente.ObservacoesLider = observacoes;
            _context.PareMeioAmbiente.Update(pareMeioAmbiente);
            _context.SaveChanges();

            return Ok();
        }

        [Authorize(Roles = "Lider, Admin")]
        [HttpPut("ReprovacaoLider")]
        public async Task<IActionResult> ReprovacaoLider([FromForm] int id, [FromForm] string? observacoes = null)
        {
            var pareMeioAmbiente = await _context.PareMeioAmbiente.FindAsync(id);
            if (pareMeioAmbiente == null)
            {
                return NotFound();
            }
            pareMeioAmbiente.Status = "Reprovado pelo Líder";
            pareMeioAmbiente.ObservacoesLider = observacoes;
            _context.PareMeioAmbiente.Update(pareMeioAmbiente);
            _context.SaveChanges();

            return Ok();
        }

        [Authorize(Roles = "PareMeioAmbiente, Admin")]
        [HttpPut("AprovacaoMeioAmbiente")]
        public async Task<IActionResult> AprovacaoMeioAmbiente([FromForm] int id, [FromForm] string? observacoes = null, [FromForm] int? pontuacao = null)
        {
            var pareMeioAmbiente = await _context.PareMeioAmbiente.FindAsync(id);
            if (pareMeioAmbiente == null)
            {
                return NotFound();
            }
            pareMeioAmbiente.Status = "Aprovado pelo Meio Ambiente";
            pareMeioAmbiente.ObservacoesMeioAmbiente = observacoes;
            pareMeioAmbiente.Pontuacao = pontuacao;
            _context.PareMeioAmbiente.Update(pareMeioAmbiente);
            _context.SaveChanges();

            return Ok();
        }

        [Authorize(Roles = "PareMeioAmbiente, Admin")]
        [HttpPut("ReprovacaoMeioAmbiente")]
        public async Task<IActionResult> ReprovacaoMeioAmbiente([FromForm] int id, [FromForm] string? observacoes = null, [FromForm] int? pontuacao = null)
        {
            var pareMeioAmbiente = await _context.PareMeioAmbiente.FindAsync(id);
            if (pareMeioAmbiente == null)
            {
                return NotFound();
            }
            pareMeioAmbiente.Status = "Reprovado pelo Meio Ambiente";
            pareMeioAmbiente.ObservacoesMeioAmbiente = observacoes;
            pareMeioAmbiente.Pontuacao = pontuacao;
            _context.PareMeioAmbiente.Update(pareMeioAmbiente);
            _context.SaveChanges();

            return Ok();
        }

    }
}
