// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;

namespace Schwarz.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<SchwarzUser> _userManager;
        private readonly SignInManager<SchwarzUser> _signInManager;
        private readonly SchwarzContext _context;

        public IndexModel(
            UserManager<SchwarzUser> userManager,
            SignInManager<SchwarzUser> signInManager, SchwarzContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        [Display(Name = "Usuário")]
        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
			[Display(Name = "Matrícula")]
			public int? Matricula { get; set; }

			[Required]
			[DataType(DataType.Text)]
			[Display(Name = "Nome Completo")]
			public string Nome { get; set; }

			public string Setor { get; set; } = string.Empty;

			[Display(Name = "Data de Nascimento")]
			[DataType(DataType.Date)]
			public DateTime? DataNascimento { get; set; }

			[Required]
			[Display(Name = "Está ativo?")]
			public bool Ativo { get; set; }
			public string Turno { get; set; } = string.Empty;
			public string Email { get; set; } = string.Empty;

			[Display(Name = "Líder/Gerente")]
			public int? IDFuncionarioLider { get; set; }
			public string Cargo { get; set; } = string.Empty;
			public string Ramal { get; set; } = string.Empty;
            public byte[] Foto { get; set; } = new byte[0];
            public IFormFile NovaFoto { get; set; } = null!;
			public string Telefone { get; set; } = string.Empty;
		}

        private async Task LoadAsync(SchwarzUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);

            Username = userName;

            Input = new InputModel
            {
				Matricula = user.Funcionario.Matricula,
				Nome = user.Funcionario.Nome,
                Setor = user.Funcionario.Setor,
				DataNascimento = user.Funcionario.DataNascimento,
				Ativo = user.Funcionario.Ativo,
				Turno = user.Funcionario.Turno,
                Email = user.Funcionario.Email,
				IDFuncionarioLider = user.Funcionario.IDLider,
				Cargo = user.Funcionario.Cargo,
				Ramal = user.Funcionario.Ramal,
				Telefone = user.Funcionario.Telefone,
				Foto = user.Funcionario.Foto
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            ViewData["Setores"] = new SelectList(_context.Funcionario.ToList().DistinctBy(x => x.Setor).OrderBy(x => x.Setor), "Setor", "Setor");
			await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            if(Input.Ramal != user.Funcionario.Ramal)
            {
                user.Funcionario.Ramal = Input.Ramal;
            }

			if (Input.NovaFoto != null)
			{
				using (var memoryStream = new MemoryStream())
				{
					Input.NovaFoto.CopyTo(memoryStream);
					byte[] fileBytes = memoryStream.ToArray();
					user.Funcionario.Foto = fileBytes;
				}
			}
			await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Seus dados foram atualizados";
            return RedirectToPage();
        }
    }
}
