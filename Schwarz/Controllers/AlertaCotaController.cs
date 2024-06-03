﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Schwarz.Models;
using Schwarz.Services.Interfaces;

namespace Schwarz.Controllers
{
    [Authorize(Roles = "Admin, Lider, Metrologia, Especialista")]
    public class AlertaCotaController : Controller
    {
        private readonly SchwarzContext _context;
        private readonly UserManager<SchwarzUser> _userManager;
        private readonly IUserService _userService;


        public AlertaCotaController(SchwarzContext context, UserManager<SchwarzUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _userService = userService;
        }

        [Authorize(Roles = "Admin, Lider, Especialista")]
        public async Task<IActionResult> IndexProducao()
        {
            var user = _userService.GetUser(User);
            var schwarzContext = _context.AlertaCota.Include(c => c.FuncionarioLider).Include(c => c.RegistroCotas).Include(c => c.RegistroCotas.Registro).Where(x => (x.IDFuncionarioLider == user.IDFuncionario || x.IDFuncionarioEspecialista == user.IDFuncionario) && x.AcaoContencao == null && x.AcaoCorretiva == null);
            return View(await schwarzContext.ToListAsync());
        }

        [Authorize(Roles = "Admin, Metrologia")]
        public async Task<IActionResult> IndexMetrologia()
        {
            var schwarzContext = _context.AlertaCota.Include(c => c.FuncionarioLider).Include(c => c.RegistroCotas).Include(c => c.RegistroCotas.Registro).OrderBy(x => x.RegistroCotas.Registro.DataAbertura) ;
            return View(await schwarzContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var alertasPorLider = _context.AlertaCota
            .Include(x => x.FuncionarioLider)
            .GroupBy(x => x.FuncionarioLider.Nome)
            .Select(x => new { Lider = x.Key, 
             AlertaProducao = x.Count(x => x.DataConfirmacaoProducao == null),
             AlertaMetrologia = x.Count(x => x.DataConfirmacaoProducao != null && x.DataConfirmacaoMetrologia == null)
            })
            .ToList();

            var alertasArquivados = _context.AlertaCota
            .Include(x => x.RegistroCotas)
            .GroupBy(x => x.RegistroCotas.Registro.DataFechamento.Value.Month)
            .OrderBy(x => x.Key)
            .Select(x => new {
                Mes = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Key)),
                AlertaArquivados = x.Count(x => x.DataConfirmacaoMetrologia != null)
            })
            .ToList();

            ViewBag.AlertasporLider = alertasPorLider;
            ViewBag.AlertasArquivados = alertasArquivados;

            ViewBag.TotalAlertaProducao= _context.AlertaCota.Where(x => x.DataConfirmacaoProducao == null).Count();
            ViewBag.TotalAlertaMetrologia = _context.AlertaCota.Where(x => x.DataConfirmacaoProducao != null && x.DataConfirmacaoMetrologia == null).Count();
            ViewBag.TotalAlertaArquivados = _context.AlertaCota.Where(x => x.DataConfirmacaoProducao != null && x.DataConfirmacaoMetrologia != null).Count();
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var AlertaCota = await _context.AlertaCota
                .Include(c => c.FuncionarioLider)
                .Include(c => c.RegistroCotas)
                .FirstOrDefaultAsync(m => m.IDAlertaCota == id);
            if (AlertaCota == null)
            {
                return NotFound();
            }

            return View(AlertaCota);
        }

        public IActionResult Create()
        {
            ViewData["IDFuncionarioLider"] = new SelectList(_context.Funcionario, "IDFuncionario", "IDFuncionario");
            ViewData["IDRegistroCotas"] = new SelectList(_context.RegistroCotas, "IDRegistroCotas", "IDRegistroCotas");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlertaCota AlertaCota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(AlertaCota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDFuncionarioLider"] = new SelectList(_context.Funcionario, "IDFuncionario", "IDFuncionario", AlertaCota.IDFuncionarioLider);
            ViewData["IDRegistroCotas"] = new SelectList(_context.RegistroCotas, "IDRegistroCotas", "IDRegistroCotas", AlertaCota.IDRegistroCotas);
            return View(AlertaCota);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var AlertaCota = await _context.AlertaCota.FindAsync(id);
            if (AlertaCota == null)
            {
                return NotFound();
            }
            ViewData["IDFuncionarioLider"] = new SelectList(_context.Funcionario, "IDFuncionario", "IDFuncionario", AlertaCota.IDFuncionarioLider);
            ViewData["IDRegistroCotas"] = new SelectList(_context.RegistroCotas, "IDRegistroCotas", "IDRegistroCotas", AlertaCota.IDRegistroCotas);
            return View(AlertaCota);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AlertaCota AlertaCota)
        {
            if (id != AlertaCota.IDAlertaCota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(AlertaCota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlertaCotaExists(AlertaCota.IDAlertaCota))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDFuncionarioLider"] = new SelectList(_context.Funcionario, "IDFuncionario", "IDFuncionario", AlertaCota.IDFuncionarioLider);
            ViewData["IDRegistroCotas"] = new SelectList(_context.RegistroCotas, "IDRegistroCotas", "IDRegistroCotas", AlertaCota.IDRegistroCotas);
            return View(AlertaCota);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var AlertaCota = await _context.AlertaCota
                .Include(c => c.FuncionarioLider)
                .Include(c => c.RegistroCotas)
                .FirstOrDefaultAsync(m => m.IDAlertaCota == id);
            if (AlertaCota == null)
            {
                return NotFound();
            }

            return View(AlertaCota);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var AlertaCota = await _context.AlertaCota.FindAsync(id);
            if (AlertaCota != null)
            {
                _context.AlertaCota.Remove(AlertaCota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlertaCotaExists(int id)
        {
            return _context.AlertaCota.Any(e => e.IDAlertaCota == id);
        }

        public IActionResult responderAlerta(string acaoContencao,string acaoCorretiva, int idAlertaCota, DateTime prazoAcaoContencao, DateTime prazoAcaoCorretiva)
        {
            AlertaCota alertaCota = _context.AlertaCota.Find(idAlertaCota);

            if (alertaCota == null)
            {
                return NotFound();
            }

            alertaCota.AcaoContencao = acaoContencao;
            alertaCota.PrazoAcaoContencao = prazoAcaoContencao;
            alertaCota.AcaoCorretiva = acaoCorretiva;
            alertaCota.PrazoAcaoCorretiva = prazoAcaoCorretiva;
            alertaCota.DataConfirmacaoProducao = DateTime.Now;

            _context.SaveChanges();
            return Ok();
        }

        public IActionResult aprovarAlerta(int idAlertaCota, int idFuncionarioMetrologia)
        {
            AlertaCota alertaCota = _context.AlertaCota.Find(idAlertaCota);

            if (alertaCota == null)
            {
                return NotFound();
            }

            alertaCota.ConfirmacaoMetrologia = true;
            alertaCota.IDFuncionarioMetrologia = idFuncionarioMetrologia;
            alertaCota.DataConfirmacaoMetrologia = DateTime.Now;

            _context.SaveChanges();
            return Ok();
        }

        public IActionResult reprovarAlerta(int idAlertaCota, int idFuncionarioMetrologia)
        {
            AlertaCota alertaCota = _context.AlertaCota.Find(idAlertaCota);

            if (alertaCota == null)
            {
                return NotFound();
            }

            alertaCota.ConfirmacaoMetrologia = false;
            alertaCota.IDFuncionarioMetrologia = idFuncionarioMetrologia;
            alertaCota.DataConfirmacaoMetrologia = DateTime.Now;

            _context.SaveChanges();
            return Ok();
        }
    }
}
