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
    public class PareMeioAmbienteController : ControllerBase
    {
        private readonly SchwarzContext _context;
        public PareMeioAmbienteController(SchwarzContext schwarzContext)
        {
            _context = schwarzContext;
        }

        [HttpDelete("/{id}")]
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

        [HttpPut("/AprovacaoLider")]
        public async Task<IActionResult> AprovacaoLider(int idPareMeioAmbiente, EAprovacaoPare aprovacaoPare, string? observacoes = null)
        {
            var pareMeioAmbiente= await _context.PareMeioAmbiente.FindAsync(idPareMeioAmbiente);
            if(pareMeioAmbiente == null)
            {
                return NotFound();
            }
            pareMeioAmbiente.AprovacaoLider = aprovacaoPare;
            pareMeioAmbiente.ObservacoesLider = observacoes;
            _context.Update(pareMeioAmbiente);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("/AprovacaoMeioAmbiente")]
        public async Task<IActionResult> AprovacaoMeioAmbiente(int idPareMeioAmbiente, EAprovacaoPare aprovacaoPare, string? observacoes = null)
        {
            var pareMeioAmbiente= await _context.PareMeioAmbiente.FindAsync(idPareMeioAmbiente);
            if(pareMeioAmbiente == null)
            {
                return NotFound();
            }
            pareMeioAmbiente.AprovacaoLider = aprovacaoPare;
            pareMeioAmbiente.ObservacoesLider = observacoes;
            _context.Update(pareMeioAmbiente);
            _context.SaveChanges();

            return Ok();
        }
       
    }
}
