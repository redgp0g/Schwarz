// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Schwarz.Models;

namespace Schwarz.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<SchwarzUser> _signInManager;
        private readonly UserManager<SchwarzUser> _userManager;
        private readonly IUserStore<SchwarzUser> _userStore;
        private readonly IUserEmailStore<SchwarzUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly SchwarzContext _context;

        public RegisterModel(
            UserManager<SchwarzUser> userManager,
            IUserStore<SchwarzUser> userStore,
            SignInManager<SchwarzUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            SchwarzContext context)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "O usuário é obrigatório")]
            [Display(Name = "Usuário")]
            public string Usuario { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password, ErrorMessage = "A senha é obrigatória")]
            [Display(Name = "Senha")]
            public string Password { get; set; }

            [DataType(DataType.Password,ErrorMessage = "A senha é obrigatória")]
            [Display(Name = "Senha de confirmação")]
            [Compare("Password", ErrorMessage = "A senha e a senha de confirmação não são iguas.")]
            public string ConfirmPassword { get; set; }

			[Required(ErrorMessage = "Selecione o funcionário")]
			[Display(Name = "Funcionário")]
			public int IDFuncionario { get; set; }

		}


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            ViewData["Funcionarios"] = new SelectList(_context.Funcionario.Where(x => x.Ativo && x.User == null), "IDFuncionario", "Nome");
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();
				user.IDFuncionario = Input.IDFuncionario;
				user.EmailConfirmed = true;

				await _userStore.SetUserNameAsync(user, Input.Usuario, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("O usuário criou uma nova conta com senha.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }

        private SchwarzUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<SchwarzUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(SchwarzUser)}'. " +
                    $"Ensure that '{nameof(SchwarzUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<SchwarzUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<SchwarzUser>)_userStore;
        }

    }
}
