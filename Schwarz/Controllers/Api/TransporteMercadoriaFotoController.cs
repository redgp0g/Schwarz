using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schwarz.Data;
using Schwarz.DTOs;

namespace Schwarz.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransporteMercadoriaFotoController : ControllerBase
    {
        private readonly SchwarzContext _context;

        public TransporteMercadoriaFotoController(SchwarzContext context)
        {
            _context = context;
        }

        [HttpGet("Foto/{id}")]
        public async Task<IActionResult> Foto(int id)
        {
            var transporteMercadoriaFoto = await _context.TransporteMercadoriaFoto.FindAsync(id);

            if (transporteMercadoriaFoto != null)
            {
                var fotoDto = new TransporteMercadoriaFotoDto
                {
                    IDTransporteMercadoriaFoto = transporteMercadoriaFoto.IDTransporteMercadoriaFoto,
                    IDTransporteMercadoria = transporteMercadoriaFoto.IDTransporteMercadoria,
                    Nome = transporteMercadoriaFoto.Nome,
                    ConteudoBase64 = Convert.ToBase64String(transporteMercadoriaFoto.Conteudo),
                    TipoMIME = transporteMercadoriaFoto.TipoMIME
                };

                return Ok(fotoDto);
            }

            return NotFound();
        }
    }
}
