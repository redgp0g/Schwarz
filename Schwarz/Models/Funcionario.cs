using Microsoft.AspNetCore.Identity;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class Funcionario : FuncionarioRepository
	{
		[Key]
		public int IDFuncionario { get; set; }
		public string Nome { get; set; }
		public int? Matricula { get; set; }
		public string Setor { get; set; }
		public string? Turno { get; set; }
		public bool Ativo { get; set; }

		public virtual SchwarzUser SchwarzUser{ get;set; }

		public Funcionario()
		{

		}
		public Funcionario(SchwarzContext contexto) : base(contexto)
		{
			_context = contexto;
		}
	}
}
