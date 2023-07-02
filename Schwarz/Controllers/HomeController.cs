using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Schwarz.Models;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Schwarz.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly SchwarzContext _context;
		private readonly UserManager<SchwarzUser> _userManager;
        private readonly SignInManager<SchwarzUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, SchwarzContext contexto, UserManager<SchwarzUser> userManager, SignInManager<SchwarzUser> signInManager )
		{
			_logger = logger;
			_context = contexto;
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Index()
		{
			if (_signInManager.IsSignedIn(User))
			{
				string senhabanco = _userManager.Users.First(x => x.Id == _userManager.GetUserId(User)).PasswordHash;
				var resultado = _userManager.PasswordHasher.VerifyHashedPassword(_userManager.Users.First(x => x.Id == _userManager.GetUserId(User)), senhabanco, "a123*");
                if (resultado != PasswordVerificationResult.Failed)
                {
                    TempData["MensagemTrocaSenha"] = "Por questão de segurança troque sua senha, para isso clique aqui";
                }
            }
			
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}