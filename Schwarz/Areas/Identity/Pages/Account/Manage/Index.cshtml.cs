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
using Schwarz.Areas.Identity.Data;

namespace Schwarz.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<SchwarzUser> _userManager;
        private readonly SignInManager<SchwarzUser> _signInManager;

        public IndexModel(
            UserManager<SchwarzUser> userManager,
            SignInManager<SchwarzUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [Display(Name = "Usuário")]
        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Nome Completo")]
            public string Nome{ get; set; }
            [Display(Name = "Matrícula")]
            public int? Matricula { get; set; }
            public string? Turno{ get; set; }
            public string? Setor{ get; set; }
            public string? Cargo { get; set; }
            [Display(Name = "Está ativo?")]
            public bool Ativo { get; set; }
            public int? Ramal { get; set; }
            public byte[]? Foto { get; set; }
            public IFormFile NovaFoto { get; set; }
            public DateTime? DataNascimento { get; set; }
            public string? IdAspNetUserLider { get; set; }


            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(SchwarzUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                Nome = user.Nome,
                Matricula = user.Matricula,
                Turno = user.Turno,
                Cargo = user.Cargo,
                Ativo = user.Ativo,
                Ramal = user.Ramal,
                Foto = user.Foto,
                DataNascimento = user.DataNascimento,
                IdAspNetUserLider = user.IdAspNetUserLider,
                PhoneNumber = phoneNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

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

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            if (Input.Nome != user.Nome)
            {
                user.Nome = Input.Nome;
            }
            if (Input.Matricula != user.Matricula)
            {
                user.Matricula = Input.Matricula;
            }
            if (Input.Turno != user.Turno)
            {
                user.Turno = Input.Turno;
            }
            if (Input.Setor!= user.Setor)
            {
                user.Setor = Input.Setor;
            }
            if (Input.Cargo != user.Cargo)
            {
                user.Cargo = Input.Cargo;
            }
            if (Input.Ativo != user.Ativo)
            {
                user.Ativo = Input.Ativo;
            }
            if (Input.Ramal != user.Ramal)
            {
                user.Ramal = Input.Ramal;
            }
            if (Input.NovaFoto != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    Input.NovaFoto.CopyTo(memoryStream);
                    byte[] fileBytes = memoryStream.ToArray();
                    user.Foto = fileBytes;
                }
            }
            if (Input.DataNascimento != user.DataNascimento)
            {
                user.DataNascimento = Input.DataNascimento;
            }
            if (Input.IdAspNetUserLider != user.IdAspNetUserLider)
            {
                user.IdAspNetUserLider = Input.IdAspNetUserLider;
            }
            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
