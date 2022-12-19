
using Schwarz.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schwarz.Models
{
	public class EquipeIdeia
	{

		[Key]
		public int IDEquipeIdeia { get; set; }
		[ForeignKey("Funcionario")]
		public int IDFuncionario { get; set; }
		public virtual Funcionario? Funcionario{ get; set; }

		[ForeignKey("Ideia")]
		public int IDIdeia { get; set; }
		public virtual Ideia? Ideia { get; set; }

		public EquipeIdeia(int iDFuncionario, int iDIdeia)
		{
			IDFuncionario = iDFuncionario;
			IDIdeia = iDIdeia;
		}
	}
}
