using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Castle.Core.Smtp;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schwarz.Data;
using Schwarz.Models;
using Schwarz.Services.Interfaces;

namespace Schwarz.Controllers
{
    public class PareSegurancaController : Controller
    {
        private readonly SchwarzContext _context;
        private readonly IEmailService _emailService;

        public PareSegurancaController(SchwarzContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }


        public async Task<IActionResult> Index()
        {
            var model = _context.PareSeguranca;
            return View(await model.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PareSeguranca pareSeguranca)
        {
            if (ModelState.IsValid)
            {

                pareSeguranca.IDFuncionarioLider = _context.Funcionario.Find(pareSeguranca.IDFuncionario).IDLider;

                _context.Add(pareSeguranca);
                await _context.SaveChangesAsync();
                if (pareSeguranca.Fotos != null)
                {
                    foreach (var foto in pareSeguranca.Fotos)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            foto.CopyTo(memoryStream);
                            byte[] fileBytes = memoryStream.ToArray();

                            string fileName = foto.FileName;
                            string fileMime = foto.ContentType;

                            PareSegurancaFoto pareSegurancaFoto = new(pareSeguranca.IDPareSeguranca, fileName, fileBytes, fileMime);
                            _context.PareSegurancaFoto.Add(pareSegurancaFoto);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                string nomeFuncionario = _context.Funcionario.Find(pareSeguranca.IDFuncionario).Nome;
                string emailMessage = $"Uma nova falha foi cadastrada no site do PARE por {pareSeguranca.Funcionario.Nome} cuja descrição é: {pareSeguranca.Desvio} <br/>" + "Link do site:  <a href =\"http://192.168.2.96:5242/PareSeguranca\">Sistema Integrado</a>";
                string subject = "PARE de Segurança Cadastrado";
                List<string> emails = _context.Funcionario.Where(x => x.Ativo).Where(x => x.Setor == "Segurança do Trabalho").Where(x => x.Email != null).Select(x => x.Email).ToList();
                foreach (var email in emails)
                {
                    //_emailService.SendEmail(subject, emailMessage, email);
                }
                _emailService.SendEmail(subject, emailMessage, "guilherme.gordiano@schwarz.com.br");
                //if (pareSeguranca.Funcionario.FuncionarioLider.Email != null)
                //{
                //    _emailService.SendEmail(subject, emailMessage, pareSeguranca.Funcionario.FuncionarioLider.Email);
                //}
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create", "Pare");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var pareSeguranca = await _context.PareSeguranca.FindAsync(id);
            if (pareSeguranca == null)
            {
                return NotFound();
            }
            ViewData["Setores"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).Select(x => new { x.Setor }).Distinct(), "Setor", "Setor");
            ViewData["Funcionarios"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).Select(x => new { x.IDFuncionario, x.Nome }), "IDFuncionario", "Nome");
            return View(pareSeguranca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PareSeguranca pareSeguranca)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.PareSeguranca.Update(pareSeguranca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;

                }
                return RedirectToAction("Index");
            }

            ViewData["Setores"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).Select(x => new { x.Setor }).Distinct(), "Setor", "Setor");
            ViewData["Funcionarios"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).Select(x => new { x.IDFuncionario, x.Nome }), "IDFuncionario", "Nome");
            return View(pareSeguranca);
        }

    }
}
