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
            var schwarzContext = _context.FSP.Include(f => f.Falha).Include(f => f.FuncionarioAlertaQualidade).Include(f => f.FuncionarioFMEA).Include(f => f.FuncionarioInstrucao).Include(f => f.FuncionarioNovaFSP).Include(f => f.FuncionarioPlanoControle).Include(f => f.FuncionarioPokaYoke).Include(f => f.FuncionarioTreinamento).Include(f => f.FuncionarioVerificacao).Include(f => f.NovaFSP);
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
                .Include(f => f.FuncionarioAlertaQualidade)
                .Include(f => f.FuncionarioFMEA)
                .Include(f => f.FuncionarioInstrucao)
                .Include(f => f.FuncionarioNovaFSP)
                .Include(f => f.FuncionarioPlanoControle)
                .Include(f => f.FuncionarioPokaYoke)
                .Include(f => f.FuncionarioTreinamento)
                .Include(f => f.FuncionarioVerificacao)
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
            ViewData["Funcionarios"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome");
            ViewData["FSPS"] = new SelectList(_context.FSP, "IDFSP", "Origem");
            return View();
        }

        // POST: FSP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FSPAdmin")]
        public async Task<IActionResult> Create([Bind("IDFSP,Numero,DataAbertura,DataFechamento,Produto,Codigo,Origem,IDFalha,MaodeObra,Maquina,Medicao,Material,MeioAmbiente,Metodo,PorqueFalhou1,PorqueFalhou2,PorqueFalhou3,PorqueFalhou4,PorqueFalhou5,CausaRaizFalha,PorquePassou1,PorquePassou2,PorquePassou3,PorquePassou4,PorquePassou5,CausaRaizPassou,AtualizarFMEA,QualFMEA,IDFuncionarioFMEA,PrazoFMEA,RealizadoFMEA,AtualizarInstrucao,QualInstrucao,IDFuncionarioInstrucao,PrazoInstrucao,RealizadoInstrucao,AtualizarPlanoControle,QualPlanoControle,IDFuncionarioPlanoControle,PrazoPlanoControle,RealizadoPlanoControle,UtilizarPokaYoke,QualPokaYoke,IDFuncionarioPokaYoke,PrazoPokaYoke,RealizadoPokaYoke,AplicarTreinamento,QualTreinamento,IDFuncionarioTreinamento,PrazoTreinamento,RealizadoTreinamento,EmitirAlertaQualidade,QualAlertaQualidade,IDFuncionarioAlertaQualidade,PrazoAlertaQualidade,RealizadoAlertaQualidade,IDFuncionarioVerificacao,DataVerificacao,IndicadorVerificacao,EficazVerificacao,MetodologiaVerificacao,IDNovaFSP,IDFuncionarioNovaFSP")] FSP fSP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fSP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDFalha"] = new SelectList(_context.Falha, "IDFalha", "IDFalha", fSP.IDFalha);
			ViewData["Funcionarios"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome");
			ViewData["FSPS"] = new SelectList(_context.FSP, "IDFSP", "Origem");
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
			ViewData["Funcionarios"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome");
			ViewData["FSPS"] = new SelectList(_context.FSP, "IDFSP", "Origem");
			return View(fSP);
        }

        // POST: FSP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FSPAdmin")]
        public async Task<IActionResult> Edit(int id, [Bind("IDFSP,Numero,DataAbertura,DataFechamento,Produto,Codigo,Origem,IDFalha,MaodeObra,Maquina,Medicao,Material,MeioAmbiente,Metodo,PorqueFalhou1,PorqueFalhou2,PorqueFalhou3,PorqueFalhou4,PorqueFalhou5,CausaRaizFalha,PorquePassou1,PorquePassou2,PorquePassou3,PorquePassou4,PorquePassou5,CausaRaizPassou,AtualizarFMEA,QualFMEA,IDFuncionarioFMEA,PrazoFMEA,RealizadoFMEA,AtualizarInstrucao,QualInstrucao,IDFuncionarioInstrucao,PrazoInstrucao,RealizadoInstrucao,AtualizarPlanoControle,QualPlanoControle,IDFuncionarioPlanoControle,PrazoPlanoControle,RealizadoPlanoControle,UtilizarPokaYoke,QualPokaYoke,IDFuncionarioPokaYoke,PrazoPokaYoke,RealizadoPokaYoke,AplicarTreinamento,QualTreinamento,IDFuncionarioTreinamento,PrazoTreinamento,RealizadoTreinamento,EmitirAlertaQualidade,QualAlertaQualidade,IDFuncionarioAlertaQualidade,PrazoAlertaQualidade,RealizadoAlertaQualidade,IDFuncionarioVerificacao,DataVerificacao,IndicadorVerificacao,EficazVerificacao,MetodologiaVerificacao,IDNovaFSP,IDFuncionarioNovaFSP")] FSP fSP)
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
			ViewData["Funcionarios"] = new SelectList(_context.Funcionario, "IDFuncionario", "Nome");
			ViewData["FSPS"] = new SelectList(_context.FSP, "IDFSP", "Origem");
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
                .Include(f => f.FuncionarioAlertaQualidade)
                .Include(f => f.FuncionarioFMEA)
                .Include(f => f.FuncionarioInstrucao)
                .Include(f => f.FuncionarioNovaFSP)
                .Include(f => f.FuncionarioPlanoControle)
                .Include(f => f.FuncionarioPokaYoke)
                .Include(f => f.FuncionarioTreinamento)
                .Include(f => f.FuncionarioVerificacao)
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
