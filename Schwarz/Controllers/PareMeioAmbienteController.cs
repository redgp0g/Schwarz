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
    public class PareMeioAmbienteController : Controller
    {
        private readonly SchwarzContext _context;
        private readonly IEmailService _emailService;

        public PareMeioAmbienteController(SchwarzContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            var model = _context.PareMeioAmbiente;
            return View(await model.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PareMeioAmbiente pareMeioAmbiente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pareMeioAmbiente);
                await _context.SaveChangesAsync();

                string nomeFuncionario = _context.Funcionario.Find(pareMeioAmbiente.IDFuncionario).Nome;
                string emailMessage = $"Uma nova falha foi cadastrada no site do PARE por {pareMeioAmbiente.Funcionario.Nome} cuja descrição é: {pareMeioAmbiente.Desvio} <br/>" + "Link do site:  <a href =\"http://192.168.2.96:5242/PareMeioAmbiente\">Sistema Integrado</a>";
                string subject = "PARE de Meio Ambiente Cadastrado";
                //_emailService.SendEmail(subject, emailMessage, "natalia.nadolny@schwarz.com.br");
                //if (pareMeioAmbiente.Funcionario.FuncionarioLider.Email != null)
                //{
                //    _emailService.SendEmail(subject, emailMessage, pareMeioAmbiente.Funcionario.FuncionarioLider.Email);
                //}
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create","Pare");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var pareMeioAmbiente= await _context.PareMeioAmbiente.FindAsync(id);
            if (pareMeioAmbiente == null)
            {
                return NotFound();
            }
            ViewData["Setores"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).Select(x => new { x.Setor }).Distinct(), "Setor", "Setor");
            ViewData["Funcionarios"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).Select(x => new { x.IDFuncionario, x.Nome }), "IDFuncionario", "Nome");
            return View(pareMeioAmbiente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PareMeioAmbiente pareMeioAmbiente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.PareMeioAmbiente.Update(pareMeioAmbiente);
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
            return View(pareMeioAmbiente);
        }
      
    }
}
