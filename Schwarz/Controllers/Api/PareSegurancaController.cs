using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schwarz.Data;
using Schwarz.Models;
using Schwarz.Services.Interfaces;

namespace Schwarz.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "PareSeguranca, Lider, Admin")]
    public class PareSegurancaController : ControllerBase
    {
        private readonly SchwarzContext _context;
        private readonly IEmailService _emailService;
        public PareSegurancaController(SchwarzContext schwarzContext, IEmailService emailService)
        {
            _context = schwarzContext;
            _emailService = emailService;
        }

        [Authorize(Roles = "PareSeguranca, Admin")]
        [HttpDelete("{id}")]
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

        [Authorize(Roles = "PareSeguranca, Admin")]
        [HttpDelete("Foto/{id}")]
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

        [Authorize(Roles = "PareSeguranca, Admin")]
        [HttpPost("Foto")]
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

        [Authorize(Roles = "Lider, Admin")]
        [HttpPut("PlanoAcao")]
        public async Task<IActionResult> PlanoAcao([FromForm] int id, [FromForm] string acao, [FromForm] bool realizada = false, [FromForm] DateTime? prazoAcao = null)
        {
            var pareSeguranca = await _context.PareSeguranca.FindAsync(id);
            if (pareSeguranca == null)
            {
                return NotFound();
            }

            pareSeguranca.Status = "Ação Pendente";
            pareSeguranca.AcaoLider = acao;
            pareSeguranca.PrazoAcaoLider = prazoAcao;
            if (realizada)
            {
                pareSeguranca.DataConclusao = DateTime.Now;
            }
            _context.Update(pareSeguranca);
            _context.SaveChanges();
            string emailMessage = $"Foi criada uma ação para o PARE por {pareSeguranca.Funcionario.FuncionarioLider.Nome} cuja descrição é: {acao} <br/>" + "Link do site:  <a href =\"http://192.168.2.96:5242/Pare/IndexSeguranca\">Sistema Integrado</a>";
            string subject = "Ação do Líder para PARE de Segurança";
            List<string> emails = _context.Funcionario.Where(x => x.Ativo).Where(x => x.Setor == "Segurança do Trabalho").Select(x => x.Email).ToList();
            foreach (var email in emails)
            {
                //_emailService.SendEmail(subject, emailMessage, email);
            }
            _emailService.SendEmail(subject, emailMessage, "guilherme.gordiano@schwarz.com.br");

            return Ok();
        }

        [Authorize(Roles = "Lider, Admin")]
        [HttpPut("Concluir")]
        public async Task<IActionResult> Concluir([FromForm] int id)
        {
            var pareSeguranca = await _context.PareSeguranca.FindAsync(id);
            if (pareSeguranca == null)
            {
                return NotFound();
            }
            pareSeguranca.DataConclusao= DateTime.Now;
            pareSeguranca.Status = "Ação Concluída";
            _context.Update(pareSeguranca);
            _context.SaveChanges();

            return Ok();
        }

        [Authorize(Roles = "PareSeguranca, Admin")]
        [HttpPut("Validar")]
        public async Task<IActionResult> Validar([FromForm] int id, [FromForm] string? observacoes = null)
        {
            var pareSeguranca = await _context.PareSeguranca.FindAsync(id);
            if (pareSeguranca == null)
            {
                return NotFound();
            }
            pareSeguranca.ObservacoesSeguranca = observacoes;
            pareSeguranca.DataValidado = DateTime.Now;
            pareSeguranca.Status = "Ação Validada";
            _context.Update(pareSeguranca);
            _context.SaveChanges();

            return Ok();
        }

        [Authorize(Roles = "PareSeguranca, Admin")]
        [HttpPut("Invalidar")]
        public async Task<IActionResult> Invalidar([FromForm] int id,[FromForm] string? observacoes = null)
        {
            var pareSeguranca = await _context.PareSeguranca.FindAsync(id);
            if (pareSeguranca == null)
            {
                return NotFound();
            }
            pareSeguranca.ObservacoesSeguranca = observacoes;
            pareSeguranca.Status = "Ação Invalidada";
            _context.Update(pareSeguranca);
            _context.SaveChanges();

            return Ok();
        }

    }
}
