using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schwarz.Data;
using Schwarz.DTOs;
using Schwarz.Statics;

namespace Schwarz.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize (Roles = $"{Roles.IdeiaAdmin}, {Roles.Admin}")]
    public class IdeiaController : ControllerBase
    {
        private readonly SchwarzContext _context;

        public IdeiaController(SchwarzContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ideia = await _context.Ideia.FindAsync(id);

            if (ideia != null)
            {
                _context.IdeiaAnexo.RemoveRange(ideia.IdeiaAnexo);
                _context.IdeiaEquipe.RemoveRange(ideia.IdeiaEquipe);
                _context.Ideia.Remove(ideia);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }
    }
}
