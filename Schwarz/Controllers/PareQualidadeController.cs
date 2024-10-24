using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Castle.Core.Smtp;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schwarz.Data;
using Schwarz.Models;
using Schwarz.Services.Interfaces;
using Schwarz.Statics;

namespace Schwarz.Controllers
{
    public class PareQualidadeController : Controller
    {
        private readonly SchwarzContext _context;
        private readonly IEmailService _emailService;

        public PareQualidadeController(SchwarzContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            var model = _context.PareQualidade;
            return View(await model.ToListAsync());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PareQualidade pareQualidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pareQualidade);
                await _context.SaveChangesAsync();
                string subject = "PARE de Qualidade do Produto Cadastrado";
                string nomeFuncionario = _context.Funcionario.Find(pareQualidade.IDFuncionario).Nome;
                string emailMessage = $"PARE de Qualidade cadastrada por: {nomeFuncionario} <br/> Descrição: {pareQualidade.Descricao} <br/>" + "Link do site:  <a href =\"http://192.168.2.96:5242/PareQualidade\">Sistema Integrado</a>";

                _emailService.SendEmail(subject, emailMessage, "rtavares@schwarz.com.br");
                _emailService.SendEmail(subject, emailMessage, "thiago.iaczkowski@schwarz.com.br");
                _emailService.SendEmail(subject, emailMessage, "jose@schwarz.com.br");

                if (pareQualidade.Funcionario.FuncionarioLider.Email != null)
                {
                    _emailService.SendEmail(subject, emailMessage, pareQualidade.Funcionario.FuncionarioLider.Email);
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create", "Pare");
        }

        [HttpGet]
        [Authorize(Roles = $"{Roles.PareQualidade}, {Roles.Admin}")]
        public async Task<IActionResult> Edit(int id)
        {
            var pareQualidade = await _context.PareQualidade.FindAsync(id);
            if (pareQualidade == null)
            {
                return NotFound();
            }
            ViewData["Falhas"] = new SelectList(_context.Falha, "CodigoEDescricao", "CodigoEDescricao");
            ViewData["Setores"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).Select(x => new { x.Setor }).Distinct(), "Setor", "Setor");
            ViewData["Funcionarios"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).Select(x => new { x.IDFuncionario, x.Nome }), "IDFuncionario", "Nome");
            return View(pareQualidade);
        }

        [HttpPost]
        [Authorize(Roles = $"{Roles.PareQualidade}, {Roles.Admin}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PareQualidade pareQualidade)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.PareQualidade.Update(pareQualidade);
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
            return View(pareQualidade);
        }
    }
}
