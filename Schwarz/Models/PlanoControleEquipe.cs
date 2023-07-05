using Schwarz.Areas.Identity.Data;
using Schwarz.Data;
using Schwarz.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class PlanoControleEquipe
	{
		[Key]
		public int IDPlanoControleEquipe { get; set; }
		[ForeignKey("PlanoControle")]
        public int IDPlanoControle { get; set; }
		public virtual PlanoControle PlanoControle { get; set; }
		[ForeignKey("Funcionario")]
        public int IDFuncionario{ get; set; }
		public virtual Funcionario Funcionario { get; set; }

        private readonly SchwarzContext _context;
		public PlanoControleEquipe()
		{

		}
		public PlanoControleEquipe(SchwarzContext contexto)
		{
			_context = contexto;
		}

		public PlanoControleEquipe (int iDFuncionario, int iDPlanoControle)
		{
			IDFuncionario = iDFuncionario;
			IDPlanoControle = iDPlanoControle;
		}

	}
}
