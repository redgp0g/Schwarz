using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schwarz.Data;
using Schwarz.Models;

namespace Schwarz.Controllers
{
    public class FSPController : Controller
    {
        private readonly SchwarzContext _context;

        public FSPController(SchwarzContext context)
        {
            _context = context;
        }

        // GET: FSP
        [Authorize(Roles = "FSPAdmin")]
        public async Task<IActionResult> Index()
        {
            var schwarzContext = _context.FSP.Include(f => f.Falha).Include(f => f.SchwarzUserAlertaQualidade).Include(f => f.SchwarzUserFMEA).Include(f => f.SchwarzUserInstrucao).Include(f => f.SchwarzUserNovaFSP).Include(f => f.SchwarzUserPlanoControle).Include(f => f.SchwarzUserPokaYoke).Include(f => f.SchwarzUserTreinamento).Include(f => f.SchwarzUserVerificacao).Include(f => f.NovaFSP);
            return View(await schwarzContext.ToListAsync());
        }

        // GET: FSP/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FSP == null)
            {
                return NotFound();
            }

            var fSP = await _context.FSP
                .Include(f => f.Falha)
                .Include(f => f.SchwarzUserAlertaQualidade)
                .Include(f => f.SchwarzUserFMEA)
                .Include(f => f.SchwarzUserInstrucao)
                .Include(f => f.SchwarzUserNovaFSP)
                .Include(f => f.SchwarzUserPlanoControle)
                .Include(f => f.SchwarzUserPokaYoke)
                .Include(f => f.SchwarzUserTreinamento)
                .Include(f => f.SchwarzUserVerificacao)
                .Include(f => f.NovaFSP)
                .FirstOrDefaultAsync(m => m.IDFSP == id);
            if (fSP == null)
            {
                return NotFound();
            }

            return View(fSP);
        }

        // GET: FSP/Create
        [Authorize(Roles = "FSPAdmin")]
        public IActionResult Create()
        {
            var falhas = _context.Falha.ToList();
            var falhaList = new List<SelectListItem>();
            foreach (var falha in falhas)
            {
                falhaList.Add(new SelectListItem
                {
                    Value = falha.IDFalha.ToString(),
                    Text = $"{falha.Identificacao}{falha.Codigo} - {falha.Descricao}"
                });
            }
            ViewData["Falhas"] = falhaList;
            ViewData["IDSchwarzUserAlertaQualidade"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome");
            ViewData["IDSchwarzUserFMEA"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome");
            ViewData["IDSchwarzUserInstrucao"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome");
            ViewData["IDSchwarzUserNovaFSP"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome");
            ViewData["IDSchwarzUserPlanoControle"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome");
            ViewData["IDSchwarzUserPokaYoke"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome");
            ViewData["IDSchwarzUserTreinamento"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome");
            ViewData["IDSchwarzUserVerificacao"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome");
            ViewData["IDNovaFSP"] = new SelectList(_context.FSP, "IDFSP", "Origem");
            return View();
        }

        // POST: FSP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FSPAdmin")]
        public async Task<IActionResult> Create([Bind("IDFSP,Numero,DataAbertura,DataFechamento,Produto,Codigo,Origem,IDFalha,MaodeObra,Maquina,Medicao,Material,MeioAmbiente,Metodo,PorqueFalhou1,PorqueFalhou2,PorqueFalhou3,PorqueFalhou4,PorqueFalhou5,CausaRaizFalha,PorquePassou1,PorquePassou2,PorquePassou3,PorquePassou4,PorquePassou5,CausaRaizPassou,AtualizarFMEA,QualFMEA,IDSchwarzUserFMEA,PrazoFMEA,RealizadoFMEA,AtualizarInstrucao,QualInstrucao,IDSchwarzUserInstrucao,PrazoInstrucao,RealizadoInstrucao,AtualizarPlanoControle,QualPlanoControle,IDSchwarzUserPlanoControle,PrazoPlanoControle,RealizadoPlanoControle,UtilizarPokaYoke,QualPokaYoke,IDSchwarzUserPokaYoke,PrazoPokaYoke,RealizadoPokaYoke,AplicarTreinamento,QualTreinamento,IDSchwarzUserTreinamento,PrazoTreinamento,RealizadoTreinamento,EmitirAlertaQualidade,QualAlertaQualidade,IDSchwarzUserAlertaQualidade,PrazoAlertaQualidade,RealizadoAlertaQualidade,IDSchwarzUserVerificacao,DataVerificacao,IndicadorVerificacao,EficazVerificacao,MetodologiaVerificacao,IDNovaFSP,IDSchwarzUserNovaFSP")] FSP fSP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fSP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDFalha"] = new SelectList(_context.Falha, "IDFalha", "IDFalha", fSP.IDFalha);
            ViewData["IDSchwarzUserAlertaQualidade"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", fSP.IDSchwarzUserAlertaQualidade);
            ViewData["IDSchwarzUserFMEA"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", fSP.IDSchwarzUserFMEA);
            ViewData["IDSchwarzUserInstrucao"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", fSP.IDSchwarzUserInstrucao);
            ViewData["IDSchwarzUserNovaFSP"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", fSP.IDSchwarzUserNovaFSP);
            ViewData["IDSchwarzUserPlanoControle"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", fSP.IDSchwarzUserPlanoControle);
            ViewData["IDSchwarzUserPokaYoke"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", fSP.IDSchwarzUserPokaYoke);
            ViewData["IDSchwarzUserTreinamento"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", fSP.IDSchwarzUserTreinamento);
            ViewData["IDSchwarzUserVerificacao"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", fSP.IDSchwarzUserVerificacao);
            ViewData["IDNovaFSP"] = new SelectList(_context.FSP, "IDFSP", "Numero", fSP.IDNovaFSP);
            return View(fSP);
        }

        // GET: FSP/Edit/5
        [Authorize(Roles = "FSPAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FSP == null)
            {
                return NotFound();
            }

            var fSP = await _context.FSP.FindAsync(id);
            if (fSP == null)
            {
                return NotFound();
            }
            ViewData["IDFalha"] = new SelectList(_context.Falha, "IDFalha", "IDFalha", fSP.IDFalha);
            ViewData["IDSchwarzUserAlertaQualidade"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", fSP.IDSchwarzUserAlertaQualidade);
            ViewData["IDSchwarzUserFMEA"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", fSP.IDSchwarzUserFMEA);
            ViewData["IDSchwarzUserInstrucao"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", fSP.IDSchwarzUserInstrucao);
            ViewData["IDSchwarzUserNovaFSP"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", fSP.IDSchwarzUserNovaFSP);
            ViewData["IDSchwarzUserPlanoControle"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", fSP.IDSchwarzUserPlanoControle);
            ViewData["IDSchwarzUserPokaYoke"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", fSP.IDSchwarzUserPokaYoke);
            ViewData["IDSchwarzUserTreinamento"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", fSP.IDSchwarzUserTreinamento);
            ViewData["IDSchwarzUserVerificacao"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "Nome", fSP.IDSchwarzUserVerificacao);
            ViewData["IDNovaFSP"] = new SelectList(_context.FSP, "IDFSP", "Numero", fSP.IDNovaFSP);
            return View(fSP);
        }

        // POST: FSP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FSPAdmin")]
        public async Task<IActionResult> Edit(int id, [Bind("IDFSP,Numero,DataAbertura,DataFechamento,Produto,Codigo,Origem,IDFalha,MaodeObra,Maquina,Medicao,Material,MeioAmbiente,Metodo,PorqueFalhou1,PorqueFalhou2,PorqueFalhou3,PorqueFalhou4,PorqueFalhou5,CausaRaizFalha,PorquePassou1,PorquePassou2,PorquePassou3,PorquePassou4,PorquePassou5,CausaRaizPassou,AtualizarFMEA,QualFMEA,IDSchwarzUserFMEA,PrazoFMEA,RealizadoFMEA,AtualizarInstrucao,QualInstrucao,IDSchwarzUserInstrucao,PrazoInstrucao,RealizadoInstrucao,AtualizarPlanoControle,QualPlanoControle,IDSchwarzUserPlanoControle,PrazoPlanoControle,RealizadoPlanoControle,UtilizarPokaYoke,QualPokaYoke,IDSchwarzUserPokaYoke,PrazoPokaYoke,RealizadoPokaYoke,AplicarTreinamento,QualTreinamento,IDSchwarzUserTreinamento,PrazoTreinamento,RealizadoTreinamento,EmitirAlertaQualidade,QualAlertaQualidade,IDSchwarzUserAlertaQualidade,PrazoAlertaQualidade,RealizadoAlertaQualidade,IDSchwarzUserVerificacao,DataVerificacao,IndicadorVerificacao,EficazVerificacao,MetodologiaVerificacao,IDNovaFSP,IDSchwarzUserNovaFSP")] FSP fSP)
        {
            if (id != fSP.IDFSP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fSP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FSPExists(fSP.IDFSP))
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
            ViewData["IDFalha"] = new SelectList(_context.Falha, "IDFalha", "IDFalha", fSP.IDFalha);
            ViewData["IDSchwarzUserAlertaQualidade"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "IDSchwarzUser", fSP.IDSchwarzUserAlertaQualidade);
            ViewData["IDSchwarzUserFMEA"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "IDSchwarzUser", fSP.IDSchwarzUserFMEA);
            ViewData["IDSchwarzUserInstrucao"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "IDSchwarzUser", fSP.IDSchwarzUserInstrucao);
            ViewData["IDSchwarzUserNovaFSP"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "IDSchwarzUser", fSP.IDSchwarzUserNovaFSP);
            ViewData["IDSchwarzUserPlanoControle"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "IDSchwarzUser", fSP.IDSchwarzUserPlanoControle);
            ViewData["IDSchwarzUserPokaYoke"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "IDSchwarzUser", fSP.IDSchwarzUserPokaYoke);
            ViewData["IDSchwarzUserTreinamento"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "IDSchwarzUser", fSP.IDSchwarzUserTreinamento);
            ViewData["IDSchwarzUserVerificacao"] = new SelectList(_context.SchwarzUser, "IDSchwarzUser", "IDSchwarzUser", fSP.IDSchwarzUserVerificacao);
            ViewData["IDNovaFSP"] = new SelectList(_context.FSP, "IDFSP", "Origem", fSP.IDNovaFSP);
            return View(fSP);
        }

        // GET: FSP/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FSP == null)
            {
                return NotFound();
            }

            var fSP = await _context.FSP
                .Include(f => f.Falha)
                .Include(f => f.SchwarzUserAlertaQualidade)
                .Include(f => f.SchwarzUserFMEA)
                .Include(f => f.SchwarzUserInstrucao)
                .Include(f => f.SchwarzUserNovaFSP)
                .Include(f => f.SchwarzUserPlanoControle)
                .Include(f => f.SchwarzUserPokaYoke)
                .Include(f => f.SchwarzUserTreinamento)
                .Include(f => f.SchwarzUserVerificacao)
                .Include(f => f.NovaFSP)
                .FirstOrDefaultAsync(m => m.IDFSP == id);
            if (fSP == null)
            {
                return NotFound();
            }

            return View(fSP);
        }

        // POST: FSP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FSPAdmin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FSP == null)
            {
                return Problem("Entity set 'SchwarzContext.FSP'  is null.");
            }
            var fSP = await _context.FSP.FindAsync(id);
            if (fSP != null)
            {
                _context.FSP.Remove(fSP);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FSPExists(int id)
        {
          return (_context.FSP?.Any(e => e.IDFSP == id)).GetValueOrDefault();
        }
    }
}
