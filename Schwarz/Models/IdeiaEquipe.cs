using Microsoft.AspNetCore.Identity;
using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class IdeiaEquipe
	{

		[Key]
		public int IDIdeiaEquipe { get; set; }
		[ForeignKey("Funcionario")]
		public int IDFuncionario { get; set; }
		public virtual Funcionario? Funcionario{ get; set; }

		[ForeignKey("Ideia")]
		public int IDIdeia { get; set; }
		public virtual Ideia Ideia { get; set; }
		public decimal? Reconhecimento { get; set; }

        private readonly SchwarzContext _context;
        public IdeiaEquipe()
		{

		}
		public IdeiaEquipe(SchwarzContext contexto)
		{
			_context = contexto;
		}
		public IdeiaEquipe(int iDFuncionario, int iDIdeia)
		{
			IDFuncionario = iDFuncionario;
			IDIdeia = iDIdeia;
		}
	}
}
