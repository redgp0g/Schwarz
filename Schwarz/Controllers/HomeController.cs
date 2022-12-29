﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Schwarz.Data;
using Schwarz.Models;
using System.Diagnostics;

namespace Schwarz.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly SchwarzContext _context;

		public HomeController(ILogger<HomeController> logger, SchwarzContext contexto)
		{
			_logger = logger;
			_context = contexto;
		}

		public IActionResult Index()
		{
			var funcionarios = _context.Funcionario.ToList();
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}