using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schwarz.Data;

namespace Schwarz.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PareController : ControllerBase
    {
        private readonly SchwarzContext _context;
        public PareController(SchwarzContext schwarzContext)
        {
            _context = schwarzContext;
        }

        [HttpDelete("/PareQualidade/{id}")]
        public async Task<IActionResult> DeleteQualidade(int id)
        {
            var pareQualidade = await _context.PareQualidade.FindAsync(id);
            if (pareQualidade != null)
            {
                _context.PareQualidade.Remove(pareQualidade);
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("/PareSeguranca/{id}")]
        public async Task<IActionResult> DeleteSeguranca(int id)
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
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("/PareMeioAmbiente/{id}")]
        public async Task<IActionResult> DeleteMeioAmbiente(int id)
        {
            var pareMeioAmbiente = await _context.PareMeioAmbiente.FindAsync(id);
            if (pareMeioAmbiente != null)
            {
                _context.PareMeioAmbiente.Remove(pareMeioAmbiente);
                return Ok();
            }

            return NotFound();
        }
    }
}
