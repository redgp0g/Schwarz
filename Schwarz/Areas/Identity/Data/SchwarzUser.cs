using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Schwarz.Models;

namespace Schwarz.Areas.Identity.Data;

public class SchwarzUser : IdentityUser
{
	[Required]
	[Display(Name = "Matrícula")]
	public int Matricula { get; set; }
	[Required]
	public string Nome { get; set; }
	[Required]
	public string Setor { get; set; }

    [Required]
    public string Turno { get; set; }
    [Required]
	public bool Ativo { get; set; }

}

