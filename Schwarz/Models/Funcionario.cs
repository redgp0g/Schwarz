using Microsoft.AspNetCore.Identity;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class Funcionario
	{
		[Key]
		public int IDFuncionario { get; set; }
		public string Nome { get; set; }
		public int? Matricula { get; set; }
		public string Setor { get; set; }
		public string? Turno { get; set; }
		public bool Ativo { get; set; }

		public virtual List<SchwarzUser>? SchwarzUser{ get;set; }

	}
}
