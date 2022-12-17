using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using Schwarz.Models;

namespace Schwarz.Areas.Identity.Data;

public class SchwarzUser : IdentityUser
{
	[Required(ErrorMessage = "Digite a matrícula")]
	[Display(Name = "Matrícula")]
	public int Matricula { get; set; }
	[Required(ErrorMessage = "Digite o Nome do Funcionário")]
	public string Nome { get; set; }
	[Required(ErrorMessage = "Digite o Setor do Funcionário")]
	public string Setor { get; set; }
	[Required]
	public bool Ativo { get; set; }
}


