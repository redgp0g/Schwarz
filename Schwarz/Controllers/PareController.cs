using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schwarz.Data;
using Schwarz.Models;

namespace Schwarz.Controllers
{
    public class PareController : Controller
    {
        private readonly SchwarzContext _context;

        public PareController(SchwarzContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            ViewData["Falhas"] = new SelectList(_context.Falha, "CodigoEDescricao", "CodigoEDescricao");
            ViewData["Funcionarios"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).Select(x => new { x.IDFuncionario, x.Nome }), "IDFuncionario", "Nome");
            ViewData["Setores"] = new SelectList(_context.Funcionario.Where(x => x.Ativo).Select(x => new { x.Setor }).Distinct(), "Setor", "Setor");
            return View();
        }
    }
}
