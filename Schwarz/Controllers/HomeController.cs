using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Schwarz.Models;
using Schwarz.Services.Interfaces;
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
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, SchwarzContext contexto, UserManager<SchwarzUser> userManager, SignInManager<SchwarzUser> signInManager, IUserService userService)
		{
			_logger = logger;
			_context = contexto;
			_userManager = userManager;
			_signInManager = signInManager;
			_userService = userService;
		}

		public IActionResult Index()
		{
			if (_signInManager.IsSignedIn(User))
			{
				string senhabanco = _userService.GetUser(User).PasswordHash;
				var resultado = _userManager.PasswordHasher.VerifyHashedPassword(_userManager.Users.First(x => x.Id == _userManager.GetUserId(User)), senhabanco, "a123*");
                if (resultado != PasswordVerificationResult.Failed)
                {
                    TempData["MensagemTrocaSenha"] = "Por questão de segurança troque sua senha, para isso clique aqui";
                }
            }
			
			return View();
		}
	}
}